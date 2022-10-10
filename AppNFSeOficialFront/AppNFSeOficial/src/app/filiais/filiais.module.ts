import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FiliaisRoutingModule } from './filiais-routing.module';
import { FilialListComponent } from './filial-list/filial-list.component';
import { PoModule } from '@po-ui/ng-components';


@NgModule({
  declarations: [FilialListComponent],
  imports: [
    CommonModule,
    FiliaisRoutingModule,
    PoModule
  ]
})
export class FiliaisModule { }
