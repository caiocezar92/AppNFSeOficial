import { Component } from '@angular/core';

import { PoMenuItem } from '@po-ui/ng-components';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  readonly menus: Array<PoMenuItem> = [
    { label: 'Home', link: '/', shortLabel:'Home', icon:'po-icon-home' },
    { label: 'Empresas', link: '/empresas', shortLabel:'Empresa', icon:'po-icon-company' },
    { label: 'Filiais', link: '/filiais', shortLabel:'Filial', icon:'po-icon-device-smartphone' }
  ];

}
