import { Component, HostBinding, Input, ViewEncapsulation } from '@angular/core';
import IButtonProps from './ibuttonProps';

@Component({
  selector: 'button[roundedButton], a[roundedButton]',
  standalone: true,
  templateUrl: './rounded-button.component.html',
  styleUrl: './rounded-button.component.scss',
  encapsulation: ViewEncapsulation.None
})
export class RoundedButtonComponent implements IButtonProps{
  @HostBinding('class.rounded-button') _customButtom = true;
  @HostBinding('class.rounded-button--outline') _outline = false;
  @HostBinding('class.rounded-button--primary')
  get light(): boolean {
    return this.color === 'primary'
  }
  @HostBinding('class.rounded-button--secondary')
  get dark(): boolean {
    return this.color === 'secondary'
  }

  @Input() iconAlign: 'left' | 'right' = 'left'
  @Input() color!: 'primary' | 'secondary'
  @Input() set outline(value: boolean) {
    this._outline = value !== null && `${value}` !== 'false'
  }

  constructor() {}
}
