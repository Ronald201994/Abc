import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagesComponent } from './pages.component';
/* import { PagesRoutingModule } from './pages-routing.module';
 */import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/common/material.module';
import { HttpClientModule } from '@angular/common/http';

//import { NgHttpLoaderModule } from 'ng-http-loader'; 

import { ContentComponent } from '../layouts/content/content.component';
import { ToolbarComponent } from '../layouts/toolbar/toolbar.component';
import { SideNavComponent } from '../layouts/side-nav/side-nav.component';
import { SharedModule } from 'src/app/common/shared.module';
import { EmpleadosContentComponent } from './empleados-content/empleados-content.component';

@NgModule({
  declarations: [
    ContentComponent,
    ToolbarComponent,
    SideNavComponent,
    PagesComponent, 
    EmpleadosContentComponent
  ],
  imports: [
    CommonModule,
/*     PagesRoutingModule,
 */    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    SharedModule,
    HttpClientModule,
    //NgHttpLoaderModule.forRoot()
  ],
  exports:[
    PagesComponent
  ]
})
export class PagesModule { }
