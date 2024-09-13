import { NgModule } from '@angular/core';
import { DatePipe, DecimalPipe } from '@angular/common';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ResponsiveSidePadding } from '../directives/responsive-side-padding.directive';
import { BreadcrumbModule } from 'angular-crumbs';

@NgModule({
    declarations: [
        ResponsiveSidePadding,
    ],
    imports: [
        RouterModule
    ],
    exports:[
/*         BreadcrumbModule,
 */     
        HttpClientModule,
        ResponsiveSidePadding,
        FormsModule, 
        ReactiveFormsModule,
        RouterModule
    ],
    providers:[
        DatePipe,
        DecimalPipe
    ]
  })
  export class SharedModule { }
  