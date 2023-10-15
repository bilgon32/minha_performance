import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HistoricoFeedbackService } from '../services/historico-feedback.service';
import { HistoricoFeedback } from '../models/historico-feedback.model';

@Component({
  selector: 'app-view-feedback',
  templateUrl: './view-feedback.component.html',
  styleUrls: ['./view-feedback.component.css']
})
export class ViewFeedbackComponent implements OnInit {
  public feedbackHistoryObj: HistoricoFeedback = new HistoricoFeedback();

  constructor(private historicoFeedbackService: HistoricoFeedbackService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    let id = this.route.snapshot.paramMap.get('id');

    if (!id) {
      this.router.navigate(["/my-feedback"]);
      return;
    }

    this.historicoFeedbackService.getById(id).subscribe(
      (ret) => {
        if (ret)
          this.feedbackHistoryObj = ret;
      }
    )
  }

}
