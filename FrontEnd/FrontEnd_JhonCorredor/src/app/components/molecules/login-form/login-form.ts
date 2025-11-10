import { Component, output, signal } from '@angular/core';
import { FormField } from '../form-field/form-field';
import { Button } from '../../atoms/button/button';

@Component({
  selector: 'app-login-form',
  imports: [FormField, Button],
  templateUrl: './login-form.html',
  styleUrl: './login-form.css',
})
export class LoginForm {
  email = signal<string>('');
  password = signal<string>('');
  isLoading = signal<boolean>(false);

  login = output<{ email: string; password: string }>();

  onEmailChange(value: string) {
    this.email.set(value);
  }

  onPasswordChange(value: string) {
    this.password.set(value);
  }

  onSubmit() {
    if (this.email() && this.password()) {
      this.isLoading.set(true);
      this.login.emit({
        email: this.email(),
        password: this.password()
      });
      // Reset loading after animation
      setTimeout(() => this.isLoading.set(false), 2000);
    }
  }
}
