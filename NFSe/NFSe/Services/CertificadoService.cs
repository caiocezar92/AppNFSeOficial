﻿using NFSe.Data;
using NFSe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Xml;

namespace NFSe.Services
{
    public class CertificadoService
    {
        private readonly NotaContext _context = new NotaContext();
        private string msgResultado;
        private XmlDocument XMLDoc;
        public string Assinar(string XMLString, string RefUri, X509Certificate2 X509Cert)

        {
            int resultado = 0;
            msgResultado = "Assinatura realizada com sucesso";
            try
            {
                //   certificado para ser utilizado na assinatura
                //
                string _xnome = "";
                if (X509Cert != null)
                {
                    _xnome = X509Cert.Subject.ToString();
                }
                X509Certificate2 _X509Cert = new X509Certificate2();
                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindBySubjectDistinguishedName, _xnome, false);
                if (collection1.Count == 0)
                {
                    resultado = 2;
                    msgResultado = "Problemas no certificado digital";
                }
                else
                {
                    // certificado ok
                    _X509Cert = collection1[0];
                    string x;
                    x = _X509Cert.GetKeyAlgorithm().ToString();
                    // Create a new XML document.
                    XmlDocument doc = new XmlDocument();

                    // Format the document to ignore white spaces.
                    doc.PreserveWhitespace = false;

                    // Load the passed XML file using it's name.
                    try
                    {
                        doc.LoadXml(XMLString);

                        // Verifica se a tag a ser assinada existe é única
                        int qtdeRefUri = doc.GetElementsByTagName(RefUri).Count;

                        if (qtdeRefUri == 0)
                        {
                            //  a URI indicada não existe
                            resultado = 4;
                            msgResultado = "A tag de assinatura " + RefUri.Trim() + " inexiste";
                        }
                        // Exsiste mais de uma tag a ser assinada
                        else
                        {
                            if (qtdeRefUri > 1)
                            {
                                // existe mais de uma URI indicada
                                resultado = 5;
                                msgResultado = "A tag de assinatura " + RefUri.Trim() + " não é unica";

                            }
                            //else if (_listaNum.IndexOf(doc.GetElementsByTagName(RefUri).Item(0).Attributes.ToString().Substring(1,1))>0)
                            //{
                            //    resultado = 6;
                            //    msgResultado = "Erro: Ao assinar o documento - ID deve ser string (" + doc.GetElementsByTagName(RefUri).Item(0).Attributes + ")";
                            //}
                            else
                            {
                                try
                                {

                                    // Create a SignedXml object.
                                    SignedXml signedXml = new SignedXml(doc);

                                    // Add the key to the SignedXml document 
                                    signedXml.SigningKey = _X509Cert.PrivateKey;

                                    // Create a reference to be signed
                                    Reference reference = new Reference();
                                    // pega o uri que deve ser assinada
                                    XmlAttributeCollection _Uri = doc.GetElementsByTagName(RefUri).Item(0).Attributes;
                                    foreach (XmlAttribute _atributo in _Uri)
                                    {
                                        if (_atributo.Name == "Id")
                                        {
                                            reference.Uri = string.Empty;
                                        }
                                    }

                                    // Add an enveloped transformation to the reference.
                                    XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                                    reference.AddTransform(env);

                                    XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                                    reference.AddTransform(c14);

                                    // Add the reference to the SignedXml object.
                                    signedXml.AddReference(reference);

                                    // Create a new KeyInfo object
                                    KeyInfo keyInfo = new KeyInfo();

                                    // Load the certificate into a KeyInfoX509Data object
                                    // and add it to the KeyInfo object.
                                    keyInfo.AddClause(new KeyInfoX509Data(_X509Cert));

                                    // Add the KeyInfo object to the SignedXml object.
                                    signedXml.KeyInfo = keyInfo;

                                    signedXml.ComputeSignature();

                                    // Get the XML representation of the signature and save
                                    // it to an XmlElement object.
                                    XmlElement xmlDigitalSignature = signedXml.GetXml();

                                    // Append the element to the XML document.
                                    doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
                                    XMLDoc = new XmlDocument();
                                    XMLDoc.PreserveWhitespace = false;
                                    XMLDoc = doc;
                                }
                                catch (Exception caught)
                                {
                                    resultado = 7;
                                    msgResultado = "Erro: Ao assinar o documento - " + caught.Message;
                                }
                            }
                        }
                    }
                    catch (Exception caught)
                    {
                        resultado = 3;
                        msgResultado = "Erro: XML mal formado - " + caught.Message;
                    }
                }
            }
            catch (Exception caught)
            {
                resultado = 1;
                msgResultado = "Erro: Problema ao acessar o certificado digital" + caught.Message;
            }

            return XMLDoc.InnerXml;
        }

        public X509Certificate2 GetCertificado()
        {
            CertificadoModel certificado = _context.Certificado.Where(x => x.Cnpj == "123").FirstOrDefault();
            var value64 = Convert.FromBase64String(certificado.Certificado);
            var senha = certificado.Senha;
            var certificate = new X509Certificate2(value64,
                      senha,
                      X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
            return certificate;
        }
        public CertificadoModel GetCertificadoToInsert(X509Certificate2 cert, CertificadoModel certificado)
        {
            var privateKey = cert.PrivateKey;
            var encoding = new System.Text.ASCIIEncoding();
            var base64String = Convert.ToBase64String(encoding.GetBytes(privateKey.ToString()));
            certificado.Senha = base64String;
            var certificadoBase64 = Convert.ToBase64String(cert.Export(X509ContentType.Pfx, certificado.Senha));
            certificado.FimValidade = cert.NotAfter;
            certificado.InicioValidade = cert.NotBefore;
            certificado.Certificado = certificadoBase64;
            //certificado.Senha = Security.Cryptography.Encrypt(certificado.Senha);
            certificado.Status = 1;

            return certificado;
        }
        public X509Certificate2 GetCertificado(string fullPath, string password)
        {
            try
            {
                var certerticado = new X509Certificate2(fullPath, password, X509KeyStorageFlags.Exportable);
                return certerticado;
            }
            catch (Exception ex)
            {
                throw new Exception("Senha do certificado errada");
            }
        }
    }
}
