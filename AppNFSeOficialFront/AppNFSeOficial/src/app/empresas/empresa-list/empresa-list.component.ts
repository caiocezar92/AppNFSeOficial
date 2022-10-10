import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Subscription } from 'rxjs';
import { PoTableColumn,  PoPageAction, PoTableAction, PoNotificationService, PoTableComponent } from '@po-ui/ng-components';

import { Router } from '@angular/router';

@Component({
  selector: 'app-empresa-list',
  templateUrl: './empresa-list.component.html',
  styleUrls: ['./empresa-list.component.scss']
})

export class EmpresaListComponent implements OnInit, OnDestroy {

  // Url do servidor
  private readonly url: string = 'https://localhost:5001/api/empresa';
  private readonly url2: string = 'https://localhost:5001/api/empresa/RemoveEmpresas';
  private empresasSub: Subscription;
  private empresaRemoveSub: Subscription;
  private empresasRemoveSub: Subscription;

  // Nossa lista de empresas
  public empresas: Array<any> = [];

  // Inicializa com true para a tabela aparecer com loading ativado
  public loading: boolean = true;
  //  Propriedade para carregar mais registro na tela
  public hasNext: boolean = false;

  // NOVA LISTA DE AÇÕES PARA O TABLE
  public readonly tableActions: Array<PoTableAction> = [
   { action: this.onViewEmpresa.bind(this), label: 'Visualizar' },
   { action: this.onEditEmpresa.bind(this), label: 'Editar' },
   { action: this.onRemoveEmpresa.bind(this), label: 'Remover', type: 'danger', separator: true }
  ];

  public readonly actions: Array<PoPageAction> = [
    { action: this.onNewEmpresa.bind(this), label: 'Cadastrar', icon: 'po-icon-user-add' },
    { action: this.onRemoveEmpresas.bind(this), label: 'Remover Empresas' }
  ];

  @ViewChild('table') table: PoTableComponent;
  
  constructor(
    private httpClient: HttpClient, 
    private router: Router,
    private PoNotification: PoNotificationService
    ) { }

  ngOnInit(): void {

    this.loadData();

  }

  public loadData() {
  
    this.loading = true;
    
    // Faz a requisição para o servidor
    this.empresasSub = this.httpClient.get<any>(this.url)
    .subscribe((response) => {

    this.empresas = response;
    this.loading = false;  // Final da carga, desativa o loading
    });

  }

  ngOnDestroy() {
    this.empresasSub.unsubscribe();

    if (this.empresaRemoveSub) {
      this.empresaRemoveSub.unsubscribe();
    }

    if (this.empresasRemoveSub) {
      this.empresasRemoveSub.unsubscribe();
    }
  }

  public readonly columns: Array<PoTableColumn> = [
    // Definição das colunas
    { property: 'id', label:'Identificador' },
    { property: 'nome', label:'Nome' },
    { property: 'nomeFantasia', label: 'Nome Fantasia' }
  ];


  // MÉTODO QUE SERÁ RESPONSÁVEL POR ABRIR NOSSA PÁGINA DE CRIAÇÃO
  private onNewEmpresa() {
  this.router.navigateByUrl('/empresas/novo');
  }
  
  private onViewEmpresa(empresa) {
    this.router.navigateByUrl(`/empresas/view/${empresa.id}`);
  }

  private onEditEmpresa(empresa) {
    this.router.navigateByUrl(`/empresas/edit/${empresa.id}`);
  }

  private onRemoveEmpresa(empresa) {
    this.empresaRemoveSub = this.httpClient.delete(`${this.url}/${empresa.id}`)
      .subscribe(() => {
        // EXIBIMOS UM AVISO INFORMANDO QUE O CADASTRO DO CLIENTE FOI deletado
        this.PoNotification.warning('Cadastro do empresa deletado com sucesso.');

        // REMOVE O REGISTRO DA NOSSA TABELA
        this.empresas.splice(this.empresas.indexOf(empresa), 1);

      });
  }

  private onRemoveEmpresas() {
    // PEGAMOS AS EMPRESAS SELECIONADOS DA TABELA
    const selectedEmpresas = this.table.getSelectedRows();
    // CRIAMOS UM NOVO ARRAY APENAS COM O ID DAS EMPRESAS PARA ENVIAR PARA O BACKEND
    // FAZER A EXCLUSÃO EM LOTE
    const empresasWithId = selectedEmpresas.map(empresa => (empresa.id));

    this.empresaRemoveSub = this.httpClient.request('delete', this.url, { body: empresasWithId } )
      .subscribe(() => {
        this.PoNotification.warning('Empresas apagados em lote com sucesso.');
      
        // REMOVEMOS AS EMPRESAS APAGADOS DA NOSSA TABELA
        selectedEmpresas.forEach(empresa => {
        this.empresas.splice(this.empresas.indexOf(empresa), 1);
        });
      });
  }

}
