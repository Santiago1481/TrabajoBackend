import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginCard } from '../../organisms/login-card/login-card';

@Component({
  selector: 'app-login',
  imports: [LoginCard],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  constructor(private router: Router) {}

  onLogin(credentials: { email: string; password: string }) {
    console.log('Login attempt:', credentials);
    // Aquí iría la lógica de autenticación
    // Por ahora simulamos login exitoso y redirigimos a home
    this.router.navigate(['/home']);
  }
}
