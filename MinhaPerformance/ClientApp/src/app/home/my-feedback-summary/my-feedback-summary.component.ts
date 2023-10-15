import { Component, OnInit } from '@angular/core';
import { HistoricoFeedback } from 'src/app/models/historico-feedback.model';
import { HistoricoFeedbackService } from 'src/app/services/historico-feedback.service';

@Component({
  selector: 'app-my-feedback-summary',
  templateUrl: './my-feedback-summary.component.html',
  styleUrls: ['./my-feedback-summary.component.css']
})
export class MyFeedbackSummaryComponent implements OnInit {
  public receivedFeedbacks: HistoricoFeedback[] = [];

  public isLoadingReceived: boolean = false;
  constructor(private historicoFeedbackService: HistoricoFeedbackService) { }

  ngOnInit() {
    this.isLoadingReceived = true;
    this.historicoFeedbackService.getReceived().subscribe(
      (ret) => {
        if (ret)
          this.receivedFeedbacks = ret;
        this.isLoadingReceived = false;
      }
    );
  }

}
