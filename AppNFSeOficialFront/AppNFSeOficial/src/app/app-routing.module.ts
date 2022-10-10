import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';


const routes: Routes = 
[
  { path: '', component: HomeComponent, pathMatch:'full' },

  // Rota para os cadastros
  { path: 'empresas', loadChildren: './empresas/empresas.module#EmpresasModule' },
  { path: 'filiais', loadChildren: './filiais/filiais.module#FiliaisModule' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
