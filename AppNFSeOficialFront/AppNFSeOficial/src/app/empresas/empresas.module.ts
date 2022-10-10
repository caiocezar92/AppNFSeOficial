import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmpresasRoutingModule } from './empresas-routing.module';
import { PoModule } from '@po-ui/ng-components';
import { FormsModule } from '@angular/forms';
import { EmpresaListComponent } from './empresa-list/empresa-list.component';
import { EmpresaFormComponent } from './empresa-form/empresa-form.component';
import { EmpresaViewComponent } from './empresa-view/empresa-view.component';


@NgModule({
  declarations: [
    EmpresaListComponent, 
    EmpresaFormComponent, 
    EmpresaViewComponent
    ],
  imports: [
    CommonModule,
    EmpresasRoutingModule,
    PoModule,
    FormsModule
  ]
})
export class EmpresasModule { }
