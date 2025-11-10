import { Component, input, output, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-input',
  imports: [FormsModule],
  templateUrl: './input.html',
  styleUrl: './input.css',
})
export class Input {
  type = input<'text' | 'email' | 'password'>('text');
  placeholder = input<string>('');
  value = input<string>('');
  label = input<string>('');
  required = input<boolean>(false);
  disabled = input<boolean>(false);

  valueChange = output<string>();

  currentValue = signal<string>('');

  ngOnInit() {
    this.currentValue.set(this.value());
  }

  onInputChange(value: string) {
    this.currentValue.set(value);
    this.valueChange.emit(value);
  }
}
