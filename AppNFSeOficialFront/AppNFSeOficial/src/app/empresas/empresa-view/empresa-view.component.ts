import { Component, OnDestroy, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Location} from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { PoNotificationService } from '@po-ui/ng-components';

import { Subscription } from 'rxjs';

@Component({
  selector: 'app-empresa-view',
  templateUrl: './empresa-view.component.html',
  styleUrls: ['./empresa-view.component.scss']
})

export class EmpresaViewComponent implements OnDestroy, OnInit {

  empresa: any = {};

  private readonly url: string = 'https://localhost:5001/api/Empresa';

  private empresaSub: Subscription;
  private paramsSub: Subscription;
  private empresaRemoveSub: Subscription;

  constructor(
    private httpClient: HttpClient, 
    private route: ActivatedRoute, 
    private router: Router,
    private poNotification: PoNotificationService,
    private location : Location
    ) { }

  ngOnInit() {
    // APENAS PEGAMOS O ID DA ROTA ATIVA E PASSAMOS PARA NOSSA FUNÇÃO LOADDATA
    this.paramsSub = this.route.params.subscribe(params => this.loadData(params['id']));
  }

  ngOnDestroy() {
    this.paramsSub.unsubscribe();
    this.empresaSub.unsubscribe();

    if (this.empresaRemoveSub) {
      this.empresaRemoveSub.unsubscribe();
    }
  }

  // FUNÇÃO QUE CARREGA OS DADOS DO CLIENTE
  private loadData(id) {
    // PEGA A RESPOSTA DA REQUISIÇÃO E GUARDA NA PROPRIEDADE CUSTOMER
    this.empresaSub = this.httpClient.get(`${this.url}/${id}`)
    .subscribe(response => this.empresa = response);
  
  }

  voltar() {
    this.router.navigateByUrl('empresas');
  }

  editar() {
    this.router.navigateByUrl(`empresas/edit/${this.empresa.id}`);
  }

  remover() {
    this.empresaRemoveSub = this.httpClient.delete(`${this.url}/${this.empresa.id}`)
      .subscribe(() => {
        this.poNotification.warning('Cadastro da empresa apagado com sucesso.');

        this.location.back();
      });
  }

}
