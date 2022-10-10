import { Component, OnDestroy, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

import { Subscription } from 'rxjs';
import { PoNotificationService} from '@po-ui/ng-components';

const actionInsert = 'insert';
const actionUpdate = 'update';

@Component({
  selector: 'app-empresa-form',
  templateUrl: './empresa-form.component.html',
  styleUrls: ['./empresa-form.component.scss']
})

export class EmpresaFormComponent implements OnDestroy, OnInit {

  private empresaSub: Subscription;
  private paramsSub: Subscription;

  public empresa: any = { };
  private readonly url: string = 'https://localhost:5001/api/Empresa';
  private action: string = actionInsert;

  constructor(
    private PoNotification: PoNotificationService,
    private router: Router,
    private route: ActivatedRoute,
    private httpClient: HttpClient
    ) { }

  ngOnDestroy() {

    this.paramsSub.unsubscribe();

    if (this.empresaSub) {
      this.empresaSub.unsubscribe();
    }
  }

  ngOnInit(): void {

      // VERIFICA SE EXISTE UM ID, CASO EXISTA CHAMA A FUNÇÃO LOADDATA
      this.paramsSub = this.route.params.subscribe(params => {
      if (params['id']) {
      this.loadData(params['id']);
      this.action = actionUpdate;
      }
    });

  }

  salvar() {

    const empresa = {...this.empresa};

    this.empresaSub = this.isUpdateOperation
    ? this.httpClient.put(`${this.url}/${empresa.id}`, empresa)
      .subscribe(() => this.navigateToList('Cliente atualizado com sucesso'))
    : this.httpClient.post(this.url, empresa)
      .subscribe(() => this.navigateToList('Cliente cadastrado com sucesso'));

  }

  // NOVA FUNÇÃO PARA EVITAR DUPLICIDADE (DRY)
  private navigateToList(msg: string) {
    this.PoNotification.success(msg);
  
    this.router.navigateByUrl('/empresas');
  }

  cancelar() {
    this.router.navigateByUrl('/empresas');
  }

  // FUNÇÃO QUE CARREGA OS DADOS DO CLIENTE  
  private loadData(id) {
    this.empresaSub = this.httpClient.get(`${this.url}/${id}`)
    .subscribe(response => this.empresa = response);
  }

  // GETTER PARA VERIFICAR SE ESTÁ EM MODE DE ATUALIZAÇÃO
  get isUpdateOperation() {
    return this.action === actionUpdate;
  }
  
  // GETTER PARA ATUALIZAR O TÍTULO DA PÁGINA
  get title() {
    return this.isUpdateOperation ? 'Atualizando dados da Empresa' : 'Nova Empresa';
  }

}
