import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-problem',
  templateUrl: './problem.component.html',
  styleUrls: ['./problem.component.css']
})
export class ProblemComponent implements OnInit {
  answer1: string;
  answer2: string;
  answer3: string;

  constructor() {
  }

  ngOnInit() {
    this.answer1 = localStorage.getItem('answer1');
    this.answer2 = localStorage.getItem('answer2');
    this.answer3 = localStorage.getItem('answer3');
  }
}
