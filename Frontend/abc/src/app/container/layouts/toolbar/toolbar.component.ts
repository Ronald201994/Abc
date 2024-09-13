import { Component, OnInit, Input, HostListener } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {

  @Input() collapsed = false;
  @Input() screenWidth = 0;
  
  canShowSearchAsOverlay = false;
  isOpenSearch:boolean = false;
  usuarioLogueado:any;

  selectedLanguage:any;
  isOpenLanguage = false;

  isOpenNotification:boolean = false;
  isOpenUser = false;

  userItems = [
    {
        icon: 'lock',
        label: 'Bloquear Pantalla',
        route: 'bloquear'
    },
    {
        icon: 'logout',
        label: 'Salir',
        route:'salir'
    }
  ];

  languages = [
    {
        language:'English',
        flag:'flag-eng'
    },
    {
        language:'Español',
        flag:'flag-esp'
    }       
  ]

  notifications = [
    {
        icon: 'cloud_dowload',
        subject: 'Download complete',
        description: 'Lorem ipsum dolor sit amet, consetetuer0'
    },
    {
        icon: 'cloud_upload',
        subject: 'Upload complete',
        description: 'Lorem ipsum dolor sit amet, consetetuer0'
    },
    {
        icon: 'delete',
        subject: '350 MB trash files',
        description: 'Lorem ipsum dolor sit amet, consetetuer0'
    }
  ]


  /* dataPopupChoice:DataPopupChoice = {
    titulo: '¿Desea salir del sistema?',
    descripcion: 'Todo los datos no guardados se perderan.',
    icono:'danger',
    acciones:{
      labelok: 'Aceptar',
      labelcancel: 'Cancelar'
    }
  } */

  constructor(private router:Router, public dialog: MatDialog) { }

  @HostListener('window:resize', ['$event'])
  onResize(event:any){
    this.checkCanShowSearchAsOverLay(window.innerWidth);
  }

  ngOnInit(): void {
    this.checkCanShowSearchAsOverLay(window.innerWidth);
    this.selectedLanguage= this.languages[0];
  }

  getHeadClass():string{
    let styleClass = '';
    if (this.collapsed && this.screenWidth > 768) {
      styleClass = 'head-trimmed';
    }else{
      styleClass = 'head-md-screen';
    }
    return styleClass;
  }

  checkCanShowSearchAsOverLay(innerWidth:number):void{
    if (innerWidth < 845) {
      this.canShowSearchAsOverlay = true;
    }else{
      this.canShowSearchAsOverlay = false;
      this.isOpenSearch = false;
    }
  }

  go(item:any){
 
    switch(item.route){

        case 'perfil':
          this.router.navigateByUrl('admin/panel/perfil')
          break;

        case 'bloquear':
          this.router.navigateByUrl('admin/unlock')
          break;

        case 'salir':
   
          break;
    }
  }

  limpiarLocalStorage(){
    localStorage.removeItem('as-objPago');
    localStorage.removeItem('as-vCodSolicitud');
    localStorage.removeItem('as-flujo1')
  }
}
