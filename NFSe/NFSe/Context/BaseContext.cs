using Microsoft.EntityFrameworkCore;
using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Context
{
  public class BaseContext : DbContext
  {

    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
    }

    public DbSet<EmpresaModel> CEmpresa { get; set; }
    public DbSet<FilialModel> CFilial { get; set; }
    public DbSet<ClienteModel> CCliente { get; set; }
    public DbSet<EstadoModel> CEstado { get; set; }
    public DbSet<MunicipioModel> CMunicipio { get; set; }
    public DbSet<PaisModel> CPais { get; set; }
    public DbSet<SerieModel> CSerie { get; set; }
    public DbSet<ServicoModel> CServico { get; set; }
    public DbSet<TipoBairroModel> CTipoBairro { get; set; }
    public DbSet<TipoLogradouroModel> CTipoLogradouro { get; set; }
    public DbSet<TributoModel> CTributo { get; set; }
    public DbSet<UnidadeModel> CUnidade { get; set; }



  }
}
