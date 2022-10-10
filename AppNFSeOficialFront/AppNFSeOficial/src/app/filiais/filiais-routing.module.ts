import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FilialListComponent } from './filial-list/filial-list.component';


const routes: Routes = 
[
  { path: '', component: FilialListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FiliaisRoutingModule { }
