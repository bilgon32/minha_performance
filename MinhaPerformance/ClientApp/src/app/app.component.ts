import { Component, OnInit } from '@angular/core';
import { NotificationService } from './services/notification.service';
import { Notification, NotificationType } from './models/notification.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Minha Performance';
  public notifications: Notification[] = [];

  constructor(private notificationService: NotificationService) {}

  ngOnInit() {
    this.notificationService.notifications.subscribe(
      (newNotification) => {
        this.notifications.push(newNotification);
        setTimeout(() => {
          this.closeNotification(newNotification.id)
        }, 5000);
      }
    )
  }

  public get NotificationType() {
    return NotificationType;
  }

  public closeNotification(id: string) {
    this.notifications = this.notifications.filter(not => not.id !== id);
  }
}

