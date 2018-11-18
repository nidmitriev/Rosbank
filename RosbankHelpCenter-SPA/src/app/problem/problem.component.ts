import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-problem',
  templateUrl: './problem.component.html',
  styleUrls: ['./problem.component.css']
})
export class ProblemComponent implements OnInit {
  answer1: string;
  theme1: string;
  answer2: string;
  theme2: string;
  answer3: string;
  theme3: string;

  constructor() {
  }

  ngOnInit() {
    this.answer1 = localStorage.getItem('answer1');
    this.theme1 = localStorage.getItem('theme1');
    this.answer2 = localStorage.getItem('answer2');
    this.theme2 = localStorage.getItem('theme2');
    this.answer3 = localStorage.getItem('answer3');
    this.theme3 = localStorage.getItem('theme3');
  }
}
