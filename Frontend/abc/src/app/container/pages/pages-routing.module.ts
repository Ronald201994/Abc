import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PagesComponent } from './pages.component';

const routes:Routes = [
  {
    path:'',
    component:PagesComponent,
    children:[
      { path: '', redirectTo: 'avisos', pathMatch: 'full'},
      { path: 'empleados', loadChildren:()=>import('./empleados-content/empleados-content.module').then((m)=>m.EmpleadosContentModule) },
    ]
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule]
})
export class PagesRoutingModule { }
