import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { AuthService } from '../_servises/Auth.service';
import { _getComponentHostLElementNode } from '@angular/core/src/render3/instructions';
import { AlertifyService } from '../_servises/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {
  @Output()
  cancelFeedback = new EventEmitter();
  model: any = {};

  constructor(
    public authService: AuthService,
    private alertify: AlertifyService,
    private router: Router
  ) {}

  ngOnInit() {}

  feedback() {
    this.authService.ExactlySolWasFound = false;
    this.authService.answer = null;
    this.authService.feedback(this.model).subscribe(
      () => {
        this.alertify.success('Скорее посмотри на ответ!');
        if (this.authService.ExactlySolWasFound) {
          this.alertify.success('Найдено точное решение!');
        } else {
          this.alertify.success('Точного решения не найдено! Но мы готовы предложть нескольков вариков)');
          this.router.navigate(['/problems']);
        }
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  cancel() {
    this.cancelFeedback.emit(false);
  }

  checkAmountSol() {}
}
