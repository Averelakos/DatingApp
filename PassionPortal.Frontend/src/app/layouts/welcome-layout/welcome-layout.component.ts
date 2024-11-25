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
  list!: HTMLElement | null
  toggleNav!: HTMLElement | null


  ngOnInit(): void {
    this.menu = document.getElementById('welcomeNav')
    this.list = document.getElementById('welcomeList')
    this.toggleNav = document.getElementById('toggleNav')
  }
  
  toggleButtonMenu () {
    this.toggleNav?.classList.toggle('active')
    this.menu?.classList.toggle('show')
  }

  toggleLink (event: any) {
    let parentElement = event.target.parentNode
    if (parentElement.classList.contains('active'))
      return

    this.list?.childNodes.forEach((child: any) => {
      if(child.classList.contains('active'))
        child.classList.remove('active')
    })

    parentElement.classList.add('active')

    this.menu?.classList.remove('show')
    this.toggleNav?.classList.remove('active')
    
  }
}
