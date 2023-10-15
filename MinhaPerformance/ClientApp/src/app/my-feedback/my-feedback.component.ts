import { Component, OnInit } from '@angular/core';
import { HistoricoFeedback } from '../models/historico-feedback.model';
import { HistoricoFeedbackService } from '../services/historico-feedback.service';

@Component({
  selector: 'app-my-feedback',
  templateUrl: './my-feedback.component.html',
  styleUrls: ['./my-feedback.component.css']
})
export class MyFeedbackComponent implements OnInit {
  public receivedFeedbacks: HistoricoFeedback[] = [];
  public sentFeedbacks: HistoricoFeedback[] = [];

  public isLoadingReceived: boolean = false;
  public isLoadingSent: boolean = false;

  constructor(private historicoFeedbackService: HistoricoFeedbackService) { }

  ngOnInit() {
    this.isLoadingReceived = true;
    this.isLoadingSent = true;
    this.historicoFeedbackService.getReceived().subscribe(
      (ret) => {
        if (ret)
          this.receivedFeedbacks = ret;
        this.isLoadingReceived = false;
      }
    );

    this.historicoFeedbackService.getSent().subscribe(
      (ret) => {
        if (ret)
          this.sentFeedbacks = ret;
        this.isLoadingSent = false;
      }
    );
  }

}
