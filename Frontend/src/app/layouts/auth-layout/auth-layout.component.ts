import { Component } from '@angular/core';
import { RoundedButtonComponent } from '../../shared/common/buttons/rounded-button/rounded-button.component';

@Component({
  selector: 'app-auth-layout',
  standalone: true,
  imports: [RoundedButtonComponent],
  templateUrl: './auth-layout.component.html',
  styleUrl: './auth-layout.component.scss'
})
export class AuthLayoutComponent {

}
