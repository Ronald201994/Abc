import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { far, faFileExcel, faFilePdf } from '@fortawesome/free-regular-svg-icons';
import { fas } from '@fortawesome/free-solid-svg-icons';


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  exports:[
    FontAwesomeModule
  ]
})
export class IconFontAwesomeModule {

  constructor(library:FaIconLibrary) {
    library.addIconPacks(fas,far);
    library.addIcons(
      faFileExcel,
      faFilePdf
    );
  }
}
