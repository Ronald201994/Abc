import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarEmpleadosComponent } from './container/pages/empleados-content/listar/listar-empleados.component';

const routes: Routes = [
  { path: '', component: ListarEmpleadosComponent },
  { path: 'empleados', component: ListarEmpleadosComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }