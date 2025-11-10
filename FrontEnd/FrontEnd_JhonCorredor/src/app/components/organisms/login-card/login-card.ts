import { Component, input, output } from '@angular/core';
import { LoginForm } from '../../molecules/login-form/login-form';

@Component({
  selector: 'app-login-card',
  imports: [LoginForm],
  templateUrl: './login-card.html',
  styleUrl: './login-card.css',
})
export class LoginCard {
  title = input<string>('Bienvenido');
  subtitle = input<string>('Inicia sesión para continuar');

  login = output<{ email: string; password: string }>();

  onLogin(credentials: { email: string; password: string }) {
    this.login.emit(credentials);
  }
}
