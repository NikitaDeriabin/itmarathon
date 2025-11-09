import { Component, input, output } from '@angular/core';
import { ButtonText, ModalTitle, PictureName } from '../../../app.enum';
import { ConfirmationModalLayoutWithHeader } from '../../../shared/components/modal/confirmation-modal-layout-with-header/confirmation-modal-layout-with-header';

@Component({
  selector: 'app-participant-delete-confirm-modal',
  imports: [ConfirmationModalLayoutWithHeader],
  templateUrl: './participant-delete-confirm-modal.html',
  styleUrl: './participant-delete-confirm-modal.scss',
})
export class ParticipantDeleteConfirmModal {
  readonly fullName = input.required<string>();

  readonly closeModal = output<void>();
  readonly confirmButtonAction = output<void>();
  readonly cancelButtonAction = output<void>();

  public readonly pictureName = PictureName.StNick;
  public readonly title = ModalTitle.AreYouSure;
  public readonly cancelButtonText = ButtonText.Cancel;
  public readonly confirmButtonText = ButtonText.Confirm;

  public onCloseModal(): void {
    this.closeModal.emit();
  }

  public onConfirmButtonAction(): void {
    this.confirmButtonAction.emit();
  }

  public onCancelButtonAction(): void {
    this.cancelButtonAction.emit();
  }
}
