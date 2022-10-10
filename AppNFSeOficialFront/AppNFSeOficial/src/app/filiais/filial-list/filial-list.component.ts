import { Component, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Subscription } from 'rxjs';
import { PoTableColumn } from '@po-ui/ng-components';

@Component({
  selector: 'app-filial-list',
  templateUrl: './filial-list.component.html',
  styleUrls: ['./filial-list.component.scss']
})

export class FilialListComponent implements OnInit, OnDestroy {

  // Url do servidor
  private readonly url: string = 'https://localhost:5001/api/filial';
  private filiaisSub: Subscription;

  // Nossa lista de filiais
  public filiais: Array<any> = [];

  // Inicializa com true para a tabela aparecer com loading ativado
  public loading: boolean = true;
  //  Propriedade para carregar mais registro na tela
  public hasNext: boolean = false;

  public Options = [
    {value: 'Nome'},
    {value: 'Teste'}
  ]
  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {

    this.loadData();

  }

  public onClickBusca(){
    
  }

  public loadData() {
  
    this.loading = true;

    // Faz a requisição para o servidor
    this.filiaisSub = this.httpClient.get<any>(this.url)
    .subscribe((response) => {
    
    this.filiais = response;

    // Tratando oo campos optanteSimples e incentCultural para String
    // Isso é necessário para exibir o campo com a propriedade de imagem na tela
    this.filiais.forEach(filial => {
      filial.optanteSimples = filial.optanteSimples.toString(); 
    });

    this.filiais.forEach(filial => {
      filial.incentCultural = filial.incentCultural.toString(); 
    });

    this.hasNext = response.hasNext;
    this.loading = false;  // Final da carga, desativa o loading
    });

  }

  ngOnDestroy() {
    this.filiaisSub.unsubscribe();
  }

  public subtituloSimNao = [
    { value: 'true', color: 'color-01', content: 'S', label: 'Sim' },
    { value: 'false', color: 'color-04', content: 'N', label: 'Não' },
  ]; 
  
  public readonly columns: Array<PoTableColumn> = [
    // Definição das colunas
    { property: 'id', label:'ID', width: '45px' },
    { property: 'nome', label:'Nome', width: '100px' },
    { property: 'nomeFantasia', label: 'Nome Fantasia', width: '170px' },
    { property: 'cnpj', label: 'CNPJ', width: '140px' },
    { property: 'inscEstadual', label: 'Inscrição Estadual' },
    { property: 'inscMunicipal', label: 'Inscrição Municipal' },
    { property: 'cnae', label: 'CNAE' },
    { property: 'email', label: 'E-mail', type: 'link', action: this.sendMail.bind(this) },
    { property: 'ddd', label: 'DDD', width: '57px' },
    { property: 'telefone', label: 'Telefone', width: '80px' },
    
    //{ property: 'optanteSimples', label: 'Optante pelo Simples' },
    { property: 'optanteSimples', label: 'Optante Simples', type: 'subtitle', width: '130px', subtitles: this.subtituloSimNao},

    //{ property: 'incentCultural', label: 'Incentivador Cultural' },
    { property: 'incentCultural', label: 'Incentivador Cultural', type: 'subtitle', width: '130px', subtitles: this.subtituloSimNao},

    { property: 'rua', label: 'Rua', width: '70px' },
    { property: 'numero', label: 'Numero' },
    { property: 'complemento', label: 'Complemento', width: '120px' },
    { property: 'bairro', label: 'Bairro', width: '80px' },
    { property: 'cep', label: 'CEP', width: '80px' },

  ];

  private sendMail(email, filial) {
    const body = 'Olá ${filial.name}, gostariamos de agradecer seu contato.';
    const subject = 'Contato';

    window.open('mailto:${email}?subject=${subject}&body=${body}', '_self');
  }

}
