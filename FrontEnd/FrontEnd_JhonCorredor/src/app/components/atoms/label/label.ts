import { Component, input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-label',
  imports: [CommonModule],
  templateUrl: './label.html',
  styleUrl: './label.css',
})
export class Label {
  text = input<string>('Label');
  for = input<string>('');
  required = input<boolean>(false);
  size = input<'small' | 'medium' | 'large'>('medium');
}
