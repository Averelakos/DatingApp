import { AfterViewInit, Component, ElementRef, inject, Input, ViewChild } from '@angular/core';
import { IconService } from '../components/icon.service';
import { IconInterface } from '../components/icon';

@Component({
  selector: 'svg-icon',
  standalone: true,
  imports: [],
  templateUrl: './svg-icon.component.html',
  styleUrl: './svg-icon.component.css'
})
export class SvgIconComponent implements AfterViewInit {
  @ViewChild('myname', {static: false}) svgElement!: ElementRef
  @Input() iconName : string = ''
  @Input() className : string = ''
  
  iconLibrary = inject(IconService)
  icon?: IconInterface

  ngAfterViewInit(): void {
    this.iconLibrary.loadIcons()
    this.icon = this.iconLibrary.getIcon(this.iconName)
    this.setSvgAttributes(this.svgElement!.nativeElement)
    this.createPath(this.svgElement!.nativeElement)
  }

  setSvgAttributes(svgElemenet: any) {
    svgElemenet?.setAttributeNS ('','width', this.icon?.svg.width!)
    svgElemenet?.setAttributeNS ('','height', this.icon?.svg.height!)
    svgElemenet?.setAttributeNS ('','viewBox', this.icon?.svg.viewBox!)
    svgElemenet?.setAttributeNS ('','fill', this.icon?.svg.fill!)
    svgElemenet?.setAttributeNS('', 'class', this.className!)
  }

  createPath(svgElemenet: any) {
    const path = document.createElementNS('http://www.w3.org/2000/svg',"path")
    path.setAttributeNS ('','d', this.icon?.path.d!)
    path.setAttributeNS ('','stroke',this.icon?.path.stroke!)
    path.setAttributeNS ('','stroke-width', this.icon?.path.strokeWidth!)
    path.setAttributeNS ('','stroke-linecap',this.icon?.path.strokeLinecap!)
    path.setAttributeNS ('','stroke-linejoin',this.icon?.path.strokeLinejoin!)
    svgElemenet?.appendChild(path)
  }

}
