import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmpresaFormComponent } from './empresa-form/empresa-form.component';
import { EmpresaListComponent } from './empresa-list/empresa-list.component';
import { EmpresaViewComponent } from './empresa-view/empresa-view.component';


const routes: Routes = 
[
  { path: '', component: EmpresaListComponent },
  { path: 'novo', component: EmpresaFormComponent },
  { path: 'view/:id', component: EmpresaViewComponent },
  { path: 'edit/:id', component: EmpresaFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmpresasRoutingModule { }
