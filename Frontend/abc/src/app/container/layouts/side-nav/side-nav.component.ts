import { Component, Output, EventEmitter, OnInit, HostListener } from '@angular/core';
import { animate, keyframes, style, transition, trigger } from '@angular/animations';
import { Router } from '@angular/router';

interface SideNavToggle{
  screenWidth:number;
  collapsed:boolean;
}

@Component({
  selector: 'side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss'],
  animations:[
    trigger('rotate', [
      transition(':enter',[
        animate('1000ms',
          keyframes([
            style({transform:'rotate(0deg)', offset:'0'}),
            style({transform:'rotate(2turn)', offset:'1'})
          ])
        )
      ])
    ])
  ]
})
export class SideNavComponent implements OnInit {

  @Output() onToggleSideNav:EventEmitter<SideNavToggle> = new EventEmitter();
  collapsed = false;
  screenWidth = 0;
  multiple:boolean = false; //true=>permite abrir multiple grupo de opcion

  navData: any[] = [
    {
        iCodMenu: 999,
        siNivMenu: 0,
        iOrdMenu: 0,
        vNomMenu: "Avisos",
        vDesMenu: "Avisos",
        vRutIcon: "donut_small",
        vUrlMenu: "avisos",
        bExpandir: false,
        cRol: "ADM",
        bActivo: true,
        hijos: [] // Lista de submenús vacía
    },
    // Puedes agregar más objetos aquí
];

  @HostListener('window:resize', ['$event'])
  onResize(event:any){
    this.screenWidth = window.innerWidth;
    if (this.screenWidth <= 768) {
      this.collapsed = false;
      this.onToggleSideNav.emit({collapsed:this.collapsed, screenWidth:this.screenWidth});
    }
  }

  constructor(public router:Router) { }

  ngOnInit(): void {
    this.screenWidth = window.innerWidth;
  }

  toggleCollapse():void{
    this.collapsed = !this.collapsed;
    this.onToggleSideNav.emit({collapsed:this.collapsed, screenWidth:this.screenWidth});
  }

  handleClick(item:any):void{
    this.shrinkItems(item);
    item.bExpandir = !item.bExpandir;
  }

  getActiveClass(data:any):string{
    return this.router.url.includes(data.vUrlMenu) ? 'active' : '';
  }

  shrinkItems(data:any):void{
    if (!this.multiple) {
      for(let modelItem of this.navData){
        if (data !== modelItem && modelItem.bExpandir) {
          modelItem.bExpandir = false
        }
      }
    }
  }

  closeSidenav():void{
    this.collapsed = false;
    this.onToggleSideNav.emit({collapsed:this.collapsed, screenWidth:this.screenWidth});
  }

}
