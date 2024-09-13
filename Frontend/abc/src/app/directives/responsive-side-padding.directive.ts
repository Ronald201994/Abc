import { Directive, ElementRef, OnDestroy, OnInit } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { Subscription } from 'rxjs';

@Directive({
  selector: '[sidePadding]'
})


export class ResponsiveSidePadding implements OnInit, OnDestroy {

  mediaSub: Subscription = new Subscription;

  constructor(public mediaObserver:MediaObserver, private el:ElementRef) { }

  ngOnInit(): void {
    this.mediaSub = this.mediaObserver.media$.subscribe(
      {
        next:mediaChange=>{

          this.el.nativeElement.style.paddingRight = (mediaChange.mqAlias == 'sm' || mediaChange.mqAlias == 'xs') ? '0' : '8px';
          this.el.nativeElement.style.paddingLeft = (mediaChange.mqAlias == 'sm' || mediaChange.mqAlias == 'xs') ? '0' : '8px';

        }
      }
    )
  }
  

  ngOnDestroy(): void {
    this.mediaSub.unsubscribe();
  }
}
