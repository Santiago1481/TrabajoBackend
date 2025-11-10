import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Button } from '../../atoms/button/button';

@Component({
  selector: 'app-header',
  imports: [Button],
  templateUrl: './header.html',
  styleUrl: './header.css',
})
export class Header {
  constructor(private router: Router) {}

  navigateToHome() {
    this.router.navigate(['/home']);
  }

  navigateToLogin() {
    this.router.navigate(['/login']);
  }

  downloadApk() {
    // Implementar lógica de descarga APK
    console.log('Descargando APK...');
  }
}
