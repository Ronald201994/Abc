import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/common/material.module';
import { SharedModule } from 'src/app/common/shared.module';
import { EmpeladosContentRoutingModule } from './empleados-content.routing.module';

@NgModule({
  declarations: [
   
  ],
  imports: [
    CommonModule,
    EmpeladosContentRoutingModule,
    MaterialModule,
    SharedModule
  ],
})
export class EmpleadosContentModule { }
