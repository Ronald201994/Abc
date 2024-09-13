import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ListarEmpleadosComponent } from './listar/listar-empleados.component';

const routes:Routes = [
  {
    path: '',
    component: ListarEmpleadosComponent,
    children:[
      { path:'', component:ListarEmpleadosComponent},
      { path: '', redirectTo: 'listar', pathMatch: 'full' }
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
export class EmpeladosContentRoutingModule { }
