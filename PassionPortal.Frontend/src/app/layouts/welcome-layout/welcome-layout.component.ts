import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-welcome-layout',
  standalone: true,
  imports: [],
  templateUrl: './welcome-layout.component.html',
  styleUrl: './welcome-layout.component.scss'
})
export class WelcomeLayoutComponent implements OnInit{
  menu!: HTMLElement | null

  ngOnInit(): void {
    this.menu = document.getElementById("welcomeNav")
  }
  
  toggleButtonMenu (event: any) {
    event.currentTarget.classList.toggle('active')
    this.menu?.classList.toggle('show')
  }
}
