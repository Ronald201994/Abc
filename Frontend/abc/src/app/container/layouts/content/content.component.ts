import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.scss']
})
export class ContentComponent implements OnInit {

  @Input() collapsed = false;
  @Input() screenWidth = 0;

  constructor(private cdRef:ChangeDetectorRef, private titleService:Title){

  }

  ngOnInit(): void {
   
  }

  private titlesToString(titles: any[]){
    return titles.reduce((prev, curr)=>{
      return `${curr.displayName} - ${prev}`;
    },'')
  }

  getBodyClass():string{
    let styleClass = '';
    if (this.collapsed && this.screenWidth > 768) {
      styleClass = 'body-trimmed';
    } else if(this.collapsed && this.screenWidth <= 768 && this.screenWidth > 0) {
      styleClass = 'body-md-screen';
    }
    return styleClass;
  }

}
