import { HistoricoFeedbackCriterio } from './../models/historico-feedback-criterio.model';
import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../services/feedback.service';
import { Feedback } from '../models/feedback.model';
import { HistoricoFeedback } from '../models/historico-feedback.model';
import { NotificationService } from '../services/notification.service';
import { UserService } from '../services/user.service';
import { User } from '../models/user.model';
import { HistoricoFeedbackService } from '../services/historico-feedback.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-send-feedback',
  templateUrl: './send-feedback.component.html',
  styleUrls: ['./send-feedback.component.css']
})
export class SendFeedbackComponent implements OnInit {
  public feedbackTypes: Feedback[] = [];
  public users: User[] = [];
  public selectedFeedbackType: Feedback | undefined;
  public feedbackHistoryObj: HistoricoFeedback = new HistoricoFeedback();
  public isLoadingFeedback: boolean = false;
  public isLoadingUsers: boolean = false;

  constructor(private feedbackService: FeedbackService,
    private userService: UserService,
    private historicoFeedbackService: HistoricoFeedbackService,
    private notificationService: NotificationService,
    private router: Router) { }

  ngOnInit() {
    this.isLoadingFeedback = true;
    this.isLoadingUsers = true;

    this.feedbackService.getFeedbackList().subscribe(
      (ret) => {
        this.isLoadingFeedback = false;
        if (ret)
          this.feedbackTypes = ret;
      },
      (error) => {
        this.notificationService.showError('Ocorreu um erro durante o carregamento dos tipos de Feedback');
      }
    )

    this.userService.getUsersList().subscribe(
      (ret) => {
        this.isLoadingUsers = false;
        if (ret)
          this.users = ret;
      },
      (error) => {
        this.notificationService.showError('Ocorreu um erro durante o carregamento da lista de usuários');
      }
    )
  }

  public selectFeedbackType(e: any) {
    let selectedItemId = e?.target?.value;
    if (selectedItemId)
      this.selectedFeedbackType = this.feedbackTypes.find(feedback => feedback.id === selectedItemId);
    else
      this.selectedFeedbackType = undefined;

    this.feedbackHistoryObj = new HistoricoFeedback();
    this.feedbackHistoryObj.feedbackId = selectedItemId;
    this.selectedFeedbackType?.criterios.forEach(crit => {
      let _histFeedCrit = new HistoricoFeedbackCriterio({
        criterioId: crit.id
      });

      this.feedbackHistoryObj.historicoFeedbackCriterios.push(_histFeedCrit);
    });
  }

  public changeFeedback(criterioId: string, quantitative: boolean, value: string = "") {
    if (!quantitative) {
      value = (document.querySelector(`#input${criterioId}`) as HTMLInputElement).value
    }

    let idx = this.feedbackHistoryObj.historicoFeedbackCriterios.findIndex((hfc: HistoricoFeedbackCriterio) => hfc.criterioId == criterioId);

    this.feedbackHistoryObj.historicoFeedbackCriterios[idx].valor = value;
  }

  public sendFeedback() {
    if (!this.canSave()) return;

    this.historicoFeedbackService.sendFeedback(this.feedbackHistoryObj).subscribe(
      (ret) => {
        console.log("🚀 ~ file: send-feedback.component.ts:91 ~ SendFeedbackComponent ~ sendFeedback ~ ret:", ret)
        this.notificationService.showSuccess('Feedback enviado com sucesso!');
        this.router.navigate(['/']);
      },
      (err) => {
        console.log("🚀 ~ file: send-feedback.component.ts:95 ~ SendFeedbackComponent ~ sendFeedback ~ err:", err)
        this.notificationService.showError('Houve um erro no procesamento: ' + err?.message);
      }
    )
  }

  public canSave() {
    if (this.feedbackHistoryObj.historicoFeedbackCriterios.filter(hfc => !hfc.valor || hfc.valor == "").length > 0 || this.feedbackHistoryObj.receptorId == "")
      return false;

    return true;
  }

}
