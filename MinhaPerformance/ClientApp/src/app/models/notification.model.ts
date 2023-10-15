export class Notification {
  public id: string = Date.now().toString();
  public message: string = "";
  public type: NotificationType = NotificationType.Success;

  constructor(init?: Partial<Notification>) {
    if (init) Object.assign(this, init);
  }
}

export enum NotificationType {
  Success,
  Error,
}
