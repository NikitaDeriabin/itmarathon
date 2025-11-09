import { Component, input, output } from '@angular/core';

import { fadeIn } from '../../../../utils/animations';
import { FADE_IN_ANIMATION_DURATION_MS } from '../../../../app.constants';
import { ButtonText } from '../../../../app.enum';
import { Button } from '../../button/button';
import { FocusTrap } from '../../../../core/directives/focus-trap';
import { ParentModalLayout } from '../../../../core/directives/parent-modal-layout';
import { IconButton } from '../../icon-button/icon-button';

@Component({
  selector: 'app-confirmation-modal-layout-with-header',
  imports: [Button, IconButton, FocusTrap],
  templateUrl: './confirmation-modal-layout-with-header.html',
  styleUrl: './confirmation-modal-layout-with-header.scss',
  animations: [fadeIn(FADE_IN_ANIMATION_DURATION_MS)],
})
export class ConfirmationModalLayoutWithHeader extends ParentModalLayout {
  readonly cancelButtonText = input.required<ButtonText>();
  readonly confirmButtonText = input.required<ButtonText>();

  readonly confirmButtonAction = output<void>();
  readonly cancelButtonAction = output<void>();

  public onConfirmButtonClick(): void {
    this.confirmButtonAction.emit();
  }

  public onCancelButtonClick(): void {
    this.cancelButtonAction.emit();
  }
}
