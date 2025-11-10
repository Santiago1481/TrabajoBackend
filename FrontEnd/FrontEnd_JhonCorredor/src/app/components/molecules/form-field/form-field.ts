import { Component, input, output } from '@angular/core';
import { Label } from '../../atoms/label/label';
import { Input } from '../../atoms/input/input';

@Component({
  selector: 'app-form-field',
  imports: [Label, Input],
  templateUrl: './form-field.html',
  styleUrl: './form-field.css',
})
export class FormField {
  label = input<string>('Field');
  type = input<'text' | 'email' | 'password'>('text');
  placeholder = input<string>('');
  value = input<string>('');
  required = input<boolean>(false);
  disabled = input<boolean>(false);

  valueChange = output<string>();

  get labelId(): string {
    return 'input-' + this.label().toLowerCase().replace(/\s+/g, '-');
  }
}
