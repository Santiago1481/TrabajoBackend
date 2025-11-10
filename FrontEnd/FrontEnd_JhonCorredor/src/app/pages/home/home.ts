import { Component } from '@angular/core';
import { Header } from '../../components/templates/header/header';
import { Hero } from '../../components/templates/hero/hero';
import { Features } from '../../components/templates/features/features';
import { Footer } from '../../components/templates/footer/footer';

@Component({
  selector: 'app-home',
  imports: [Header, Hero, Features, Footer],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {

}
