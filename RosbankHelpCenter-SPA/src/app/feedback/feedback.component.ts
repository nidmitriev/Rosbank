import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { AuthService } from '../_servises/Auth.service';
import { _getComponentHostLElementNode } from '@angular/core/src/render3/instructions';
import { AlertifyService } from '../_servises/alertify.service';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})

export class FeedbackComponent implements OnInit {
  @Output()
  cancelFeedback = new EventEmitter();
  model: any = {};

  constructor(public authService: AuthService, private alertify: AlertifyService) {}

  ngOnInit() {
  }

  feedback() {
    this.authService.feedback(this.model).subscribe(
      () => {
        this.alertify.success('Feddback is sent successfuly');
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  cancel() {
    this.cancelFeedback.emit(false);
  }
}
