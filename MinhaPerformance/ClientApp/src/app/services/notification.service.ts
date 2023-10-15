import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Notification, NotificationType } from '../models/notification.model';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  public notifications: Subject<Notification> = new Subject<Notification>();

  constructor() { }

  public showSuccess(message: string) {
    let _notification = new Notification({
      message,
      type: NotificationType.Success
    });
    this.notifications.next(_notification);
  }

  public showError(message: string) {
    let _notification = new Notification({
      message,
      type: NotificationType.Error
    });
    this.notifications.next(_notification);
  }
}
