using System;
using Steezy.Utility;
using UnityEngine.Serialization;

namespace UnityEngine.EventSystems
{
	// Token: 0x020001A6 RID: 422
	[AddComponentMenu("Event/Custom Standalone Input Module")]
	public class CustomStandaloneInputModule : PointerInputModule
	{
		// Token: 0x06001B78 RID: 7032 RVA: 0x00142E90 File Offset: 0x00141090
		protected CustomStandaloneInputModule()
		{
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06001B79 RID: 7033 RVA: 0x00142EE5 File Offset: 0x001410E5
		// (set) Token: 0x06001B7A RID: 7034 RVA: 0x00142EED File Offset: 0x001410ED
		public bool enableMouse
		{
			get
			{
				return this.m_EnableMouse;
			}
			set
			{
				this.m_EnableMouse = value;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06001B7B RID: 7035 RVA: 0x00142EF6 File Offset: 0x001410F6
		// (set) Token: 0x06001B7C RID: 7036 RVA: 0x00142EFE File Offset: 0x001410FE
		public bool forceModuleActive
		{
			get
			{
				return this.m_ForceModuleActive;
			}
			set
			{
				this.m_ForceModuleActive = value;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06001B7D RID: 7037 RVA: 0x00142F07 File Offset: 0x00141107
		// (set) Token: 0x06001B7E RID: 7038 RVA: 0x00142F0F File Offset: 0x0014110F
		public float inputActionsPerSecond
		{
			get
			{
				return this.m_InputActionsPerSecond;
			}
			set
			{
				this.m_InputActionsPerSecond = value;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06001B7F RID: 7039 RVA: 0x00142F18 File Offset: 0x00141118
		// (set) Token: 0x06001B80 RID: 7040 RVA: 0x00142F20 File Offset: 0x00141120
		public float repeatDelay
		{
			get
			{
				return this.m_RepeatDelay;
			}
			set
			{
				this.m_RepeatDelay = value;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06001B81 RID: 7041 RVA: 0x00142F29 File Offset: 0x00141129
		// (set) Token: 0x06001B82 RID: 7042 RVA: 0x00142F31 File Offset: 0x00141131
		public string horizontalAxis
		{
			get
			{
				return this.m_HorizontalAxis;
			}
			set
			{
				this.m_HorizontalAxis = value;
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06001B83 RID: 7043 RVA: 0x00142F3A File Offset: 0x0014113A
		// (set) Token: 0x06001B84 RID: 7044 RVA: 0x00142F42 File Offset: 0x00141142
		public string verticalAxis
		{
			get
			{
				return this.m_VerticalAxis;
			}
			set
			{
				this.m_VerticalAxis = value;
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06001B85 RID: 7045 RVA: 0x00142F4B File Offset: 0x0014114B
		// (set) Token: 0x06001B86 RID: 7046 RVA: 0x00142F53 File Offset: 0x00141153
		public string submitButton
		{
			get
			{
				return this.m_SubmitButton;
			}
			set
			{
				this.m_SubmitButton = value;
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06001B87 RID: 7047 RVA: 0x00142F5C File Offset: 0x0014115C
		// (set) Token: 0x06001B88 RID: 7048 RVA: 0x00142F64 File Offset: 0x00141164
		public string cancelButton
		{
			get
			{
				return this.m_CancelButton;
			}
			set
			{
				this.m_CancelButton = value;
			}
		}

		// Token: 0x06001B89 RID: 7049 RVA: 0x00142F6D File Offset: 0x0014116D
		public override void UpdateModule()
		{
			this.m_LastMousePosition = this.m_MousePosition;
			this.m_MousePosition = base.input.mousePosition;
		}

		// Token: 0x06001B8A RID: 7050 RVA: 0x00142F8C File Offset: 0x0014118C
		public override bool IsModuleSupported()
		{
			return this.m_ForceModuleActive || base.input.mousePresent || base.input.touchSupported;
		}

		// Token: 0x06001B8B RID: 7051 RVA: 0x00142FB0 File Offset: 0x001411B0
		public override bool ShouldActivateModule()
		{
			if (!base.ShouldActivateModule())
			{
				return false;
			}
			bool flag = this.m_ForceModuleActive;
			flag |= base.input.GetButtonDown(this.m_SubmitButton);
			flag |= base.input.GetButtonDown(this.m_CancelButton);
			flag |= !Mathf.Approximately(base.input.GetAxisRaw(this.m_HorizontalAxis), 0f);
			flag |= !Mathf.Approximately(base.input.GetAxisRaw(this.m_VerticalAxis), 0f);
			flag |= SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.UP, StPadManager.Player.P1);
			flag |= SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.DOWN, StPadManager.Player.P1);
			flag |= SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.LEFT, StPadManager.Player.P1);
			flag |= SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.RIGHT, StPadManager.Player.P1);
			if (this.m_EnableMouse)
			{
				flag |= (this.m_MousePosition - this.m_LastMousePosition).sqrMagnitude > 0f;
				flag |= base.input.GetMouseButtonDown(0);
			}
			if (this.m_EnableMouse && base.input.touchCount > 0)
			{
				flag = true;
			}
			return flag;
		}

		// Token: 0x06001B8C RID: 7052 RVA: 0x001430C8 File Offset: 0x001412C8
		public override void ActivateModule()
		{
			base.ActivateModule();
			this.m_MousePosition = base.input.mousePosition;
			this.m_LastMousePosition = base.input.mousePosition;
			GameObject gameObject = base.eventSystem.currentSelectedGameObject;
			if (gameObject == null)
			{
				gameObject = base.eventSystem.firstSelectedGameObject;
			}
			base.eventSystem.SetSelectedGameObject(gameObject, this.GetBaseEventData());
		}

		// Token: 0x06001B8D RID: 7053 RVA: 0x00143130 File Offset: 0x00141330
		public override void DeactivateModule()
		{
			base.DeactivateModule();
			base.ClearSelection();
		}

		// Token: 0x06001B8E RID: 7054 RVA: 0x00143140 File Offset: 0x00141340
		public override void Process()
		{
			bool flag = this.SendUpdateEventToSelectedObject();
			if (base.eventSystem.sendNavigationEvents)
			{
				if (!flag)
				{
					flag |= this.SendMoveEventToSelectedObject();
				}
				if (!flag)
				{
					this.SendSubmitEventToSelectedObject();
				}
			}
			if (!this.m_EnableMouse)
			{
				return;
			}
			if (!this.ProcessTouchEvents() && base.input.mousePresent)
			{
				this.ProcessMouseEvent();
			}
		}

		// Token: 0x06001B8F RID: 7055 RVA: 0x0014319C File Offset: 0x0014139C
		private bool ProcessTouchEvents()
		{
			for (int i = 0; i < base.input.touchCount; i++)
			{
				Touch touch = base.input.GetTouch(i);
				if (touch.type != 1)
				{
					bool flag;
					bool flag2;
					PointerEventData touchPointerEventData = base.GetTouchPointerEventData(touch, ref flag, ref flag2);
					this.ProcessTouchPress(touchPointerEventData, flag, flag2);
					if (!flag2)
					{
						this.ProcessMove(touchPointerEventData);
						this.ProcessDrag(touchPointerEventData);
					}
					else
					{
						base.RemovePointerData(touchPointerEventData);
					}
				}
			}
			return base.input.touchCount > 0;
		}

		// Token: 0x06001B90 RID: 7056 RVA: 0x00143218 File Offset: 0x00141418
		protected void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released)
		{
			GameObject gameObject = pointerEvent.pointerCurrentRaycast.gameObject;
			if (pressed)
			{
				pointerEvent.eligibleForClick = true;
				pointerEvent.delta = Vector2.zero;
				pointerEvent.dragging = false;
				pointerEvent.useDragThreshold = true;
				pointerEvent.pressPosition = pointerEvent.position;
				pointerEvent.pointerPressRaycast = pointerEvent.pointerCurrentRaycast;
				base.DeselectIfSelectionChanged(gameObject, pointerEvent);
				if (pointerEvent.pointerEnter != gameObject)
				{
					base.HandlePointerExitAndEnter(pointerEvent, gameObject);
					pointerEvent.pointerEnter = gameObject;
				}
				GameObject gameObject2 = ExecuteEvents.ExecuteHierarchy<IPointerDownHandler>(gameObject, pointerEvent, ExecuteEvents.pointerDownHandler);
				if (gameObject2 == null)
				{
					gameObject2 = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject);
				}
				float unscaledTime = Time.unscaledTime;
				if (gameObject2 == pointerEvent.lastPress)
				{
					if (unscaledTime - pointerEvent.clickTime < 0.3f)
					{
						int num = pointerEvent.clickCount + 1;
						pointerEvent.clickCount = num;
					}
					else
					{
						pointerEvent.clickCount = 1;
					}
					pointerEvent.clickTime = unscaledTime;
				}
				else
				{
					pointerEvent.clickCount = 1;
				}
				pointerEvent.pointerPress = gameObject2;
				pointerEvent.rawPointerPress = gameObject;
				pointerEvent.clickTime = unscaledTime;
				pointerEvent.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(gameObject);
				if (pointerEvent.pointerDrag != null)
				{
					ExecuteEvents.Execute<IInitializePotentialDragHandler>(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.initializePotentialDrag);
				}
			}
			if (released)
			{
				ExecuteEvents.Execute<IPointerUpHandler>(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerUpHandler);
				GameObject eventHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject);
				if (pointerEvent.pointerPress == eventHandler && pointerEvent.eligibleForClick)
				{
					ExecuteEvents.Execute<IPointerClickHandler>(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerClickHandler);
				}
				else if (pointerEvent.pointerDrag != null && pointerEvent.dragging)
				{
					ExecuteEvents.ExecuteHierarchy<IDropHandler>(gameObject, pointerEvent, ExecuteEvents.dropHandler);
				}
				pointerEvent.eligibleForClick = false;
				pointerEvent.pointerPress = null;
				pointerEvent.rawPointerPress = null;
				if (pointerEvent.pointerDrag != null && pointerEvent.dragging)
				{
					ExecuteEvents.Execute<IEndDragHandler>(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.endDragHandler);
				}
				pointerEvent.dragging = false;
				pointerEvent.pointerDrag = null;
				if (pointerEvent.pointerDrag != null)
				{
					ExecuteEvents.Execute<IEndDragHandler>(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.endDragHandler);
				}
				pointerEvent.pointerDrag = null;
				ExecuteEvents.ExecuteHierarchy<IPointerExitHandler>(pointerEvent.pointerEnter, pointerEvent, ExecuteEvents.pointerExitHandler);
				pointerEvent.pointerEnter = null;
			}
		}

		// Token: 0x06001B91 RID: 7057 RVA: 0x0014343C File Offset: 0x0014163C
		protected bool SendSubmitEventToSelectedObject()
		{
			if (base.eventSystem.currentSelectedGameObject == null)
			{
				return false;
			}
			BaseEventData baseEventData = this.GetBaseEventData();
			if (base.input.GetButtonDown(this.m_SubmitButton))
			{
				ExecuteEvents.Execute<ISubmitHandler>(base.eventSystem.currentSelectedGameObject, baseEventData, ExecuteEvents.submitHandler);
			}
			if (base.input.GetButtonDown(this.m_CancelButton))
			{
				ExecuteEvents.Execute<ICancelHandler>(base.eventSystem.currentSelectedGameObject, baseEventData, ExecuteEvents.cancelHandler);
			}
			if (SingletonBehaviour<StPadManager>.Instance.GetButtonUp(StPadManager.PadButton.POSITIVE, StPadManager.Player.P1))
			{
				ExecuteEvents.Execute<ISubmitHandler>(base.eventSystem.currentSelectedGameObject, baseEventData, ExecuteEvents.submitHandler);
			}
			if (SingletonBehaviour<StPadManager>.Instance.GetButtonUp(StPadManager.PadButton.NEGATIVE, StPadManager.Player.P1))
			{
				ExecuteEvents.Execute<ICancelHandler>(base.eventSystem.currentSelectedGameObject, baseEventData, ExecuteEvents.cancelHandler);
			}
			return baseEventData.used;
		}

		// Token: 0x06001B92 RID: 7058 RVA: 0x00143514 File Offset: 0x00141714
		private Vector2 GetRawMoveVector()
		{
			Vector2 zero = Vector2.zero;
			zero.x = base.input.GetAxisRaw(this.m_HorizontalAxis);
			zero.y = base.input.GetAxisRaw(this.m_VerticalAxis);
			if (base.input.GetButtonDown(this.m_HorizontalAxis))
			{
				if (zero.x < 0f)
				{
					zero.x = -1f;
				}
				if (zero.x > 0f)
				{
					zero.x = 1f;
				}
			}
			if (base.input.GetButtonDown(this.m_VerticalAxis))
			{
				if (zero.y < 0f)
				{
					zero.y = -1f;
				}
				if (zero.y > 0f)
				{
					zero.y = 1f;
				}
			}
			if (SingletonBehaviour<StPadManager>.Instance.GetButton(StPadManager.PadButton.LEFT, StPadManager.Player.P1))
			{
				zero.x = -1f;
			}
			if (SingletonBehaviour<StPadManager>.Instance.GetButton(StPadManager.PadButton.RIGHT, StPadManager.Player.P1))
			{
				zero.x = 1f;
			}
			if (SingletonBehaviour<StPadManager>.Instance.GetButton(StPadManager.PadButton.UP, StPadManager.Player.P1))
			{
				zero.y = 1f;
			}
			if (SingletonBehaviour<StPadManager>.Instance.GetButton(StPadManager.PadButton.DOWN, StPadManager.Player.P1))
			{
				zero.y = -1f;
			}
			return zero;
		}

		// Token: 0x06001B93 RID: 7059 RVA: 0x0014364C File Offset: 0x0014184C
		protected bool SendMoveEventToSelectedObject()
		{
			float unscaledTime = Time.unscaledTime;
			Vector2 rawMoveVector = this.GetRawMoveVector();
			if (Mathf.Approximately(rawMoveVector.x, 0f) && Mathf.Approximately(rawMoveVector.y, 0f))
			{
				this.m_ConsecutiveMoveCount = 0;
				return false;
			}
			bool flag = base.input.GetButtonDown(this.m_HorizontalAxis) || base.input.GetButtonDown(this.m_VerticalAxis) || SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.LEFT, StPadManager.Player.P1) || SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.RIGHT, StPadManager.Player.P1) || SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.UP, StPadManager.Player.P1) || SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.DOWN, StPadManager.Player.P1);
			bool flag2 = Vector2.Dot(rawMoveVector, this.m_LastMoveVector) > 0f;
			if (!flag)
			{
				if (flag2 && this.m_ConsecutiveMoveCount == 1)
				{
					flag = unscaledTime > this.m_PrevActionTime + this.m_RepeatDelay;
				}
				else
				{
					flag = unscaledTime > this.m_PrevActionTime + 1f / this.m_InputActionsPerSecond;
				}
			}
			if (!flag)
			{
				return false;
			}
			AxisEventData axisEventData = this.GetAxisEventData(rawMoveVector.x, rawMoveVector.y, 0.6f);
			if (axisEventData.moveDir != 4)
			{
				ExecuteEvents.Execute<IMoveHandler>(base.eventSystem.currentSelectedGameObject, axisEventData, ExecuteEvents.moveHandler);
				if (!flag2)
				{
					this.m_ConsecutiveMoveCount = 0;
				}
				this.m_ConsecutiveMoveCount++;
				this.m_PrevActionTime = unscaledTime;
				this.m_LastMoveVector = rawMoveVector;
			}
			else
			{
				this.m_ConsecutiveMoveCount = 0;
			}
			return axisEventData.used;
		}

		// Token: 0x06001B94 RID: 7060 RVA: 0x001437B6 File Offset: 0x001419B6
		protected void ProcessMouseEvent()
		{
			this.ProcessMouseEvent(0);
		}

		// Token: 0x06001B95 RID: 7061 RVA: 0x001437C0 File Offset: 0x001419C0
		protected void ProcessMouseEvent(int id)
		{
			PointerInputModule.MouseState mousePointerEventData = this.GetMousePointerEventData(id);
			PointerInputModule.MouseButtonEventData eventData = mousePointerEventData.GetButtonState(0).eventData;
			this.m_CurrentFocusedGameObject = eventData.buttonData.pointerCurrentRaycast.gameObject;
			this.ProcessMousePress(eventData);
			this.ProcessMove(eventData.buttonData);
			this.ProcessDrag(eventData.buttonData);
			this.ProcessMousePress(mousePointerEventData.GetButtonState(1).eventData);
			this.ProcessDrag(mousePointerEventData.GetButtonState(1).eventData.buttonData);
			this.ProcessMousePress(mousePointerEventData.GetButtonState(2).eventData);
			this.ProcessDrag(mousePointerEventData.GetButtonState(2).eventData.buttonData);
			if (!Mathf.Approximately(eventData.buttonData.scrollDelta.sqrMagnitude, 0f))
			{
				ExecuteEvents.ExecuteHierarchy<IScrollHandler>(ExecuteEvents.GetEventHandler<IScrollHandler>(eventData.buttonData.pointerCurrentRaycast.gameObject), eventData.buttonData, ExecuteEvents.scrollHandler);
			}
		}

		// Token: 0x06001B96 RID: 7062 RVA: 0x001438B4 File Offset: 0x00141AB4
		protected bool SendUpdateEventToSelectedObject()
		{
			if (base.eventSystem.currentSelectedGameObject == null)
			{
				return false;
			}
			BaseEventData baseEventData = this.GetBaseEventData();
			ExecuteEvents.Execute<IUpdateSelectedHandler>(base.eventSystem.currentSelectedGameObject, baseEventData, ExecuteEvents.updateSelectedHandler);
			return baseEventData.used;
		}

		// Token: 0x06001B97 RID: 7063 RVA: 0x001438FC File Offset: 0x00141AFC
		protected void ProcessMousePress(PointerInputModule.MouseButtonEventData data)
		{
			PointerEventData buttonData = data.buttonData;
			GameObject gameObject = buttonData.pointerCurrentRaycast.gameObject;
			if (data.PressedThisFrame())
			{
				buttonData.eligibleForClick = true;
				buttonData.delta = Vector2.zero;
				buttonData.dragging = false;
				buttonData.useDragThreshold = true;
				buttonData.pressPosition = buttonData.position;
				buttonData.pointerPressRaycast = buttonData.pointerCurrentRaycast;
				base.DeselectIfSelectionChanged(gameObject, buttonData);
				GameObject gameObject2 = ExecuteEvents.ExecuteHierarchy<IPointerDownHandler>(gameObject, buttonData, ExecuteEvents.pointerDownHandler);
				if (gameObject2 == null)
				{
					gameObject2 = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject);
				}
				float unscaledTime = Time.unscaledTime;
				if (gameObject2 == buttonData.lastPress)
				{
					if (unscaledTime - buttonData.clickTime < 0.3f)
					{
						PointerEventData pointerEventData = buttonData;
						int num = pointerEventData.clickCount + 1;
						pointerEventData.clickCount = num;
					}
					else
					{
						buttonData.clickCount = 1;
					}
					buttonData.clickTime = unscaledTime;
				}
				else
				{
					buttonData.clickCount = 1;
				}
				buttonData.pointerPress = gameObject2;
				buttonData.rawPointerPress = gameObject;
				buttonData.clickTime = unscaledTime;
				buttonData.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(gameObject);
				if (buttonData.pointerDrag != null)
				{
					ExecuteEvents.Execute<IInitializePotentialDragHandler>(buttonData.pointerDrag, buttonData, ExecuteEvents.initializePotentialDrag);
				}
			}
			if (data.ReleasedThisFrame())
			{
				ExecuteEvents.Execute<IPointerUpHandler>(buttonData.pointerPress, buttonData, ExecuteEvents.pointerUpHandler);
				GameObject eventHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject);
				if (buttonData.pointerPress == eventHandler && buttonData.eligibleForClick)
				{
					ExecuteEvents.Execute<IPointerClickHandler>(buttonData.pointerPress, buttonData, ExecuteEvents.pointerClickHandler);
				}
				else if (buttonData.pointerDrag != null && buttonData.dragging)
				{
					ExecuteEvents.ExecuteHierarchy<IDropHandler>(gameObject, buttonData, ExecuteEvents.dropHandler);
				}
				buttonData.eligibleForClick = false;
				buttonData.pointerPress = null;
				buttonData.rawPointerPress = null;
				if (buttonData.pointerDrag != null && buttonData.dragging)
				{
					ExecuteEvents.Execute<IEndDragHandler>(buttonData.pointerDrag, buttonData, ExecuteEvents.endDragHandler);
				}
				buttonData.dragging = false;
				buttonData.pointerDrag = null;
				if (gameObject != buttonData.pointerEnter)
				{
					base.HandlePointerExitAndEnter(buttonData, null);
					base.HandlePointerExitAndEnter(buttonData, gameObject);
				}
			}
		}

		// Token: 0x06001B98 RID: 7064 RVA: 0x00143AF6 File Offset: 0x00141CF6
		protected GameObject GetCurrentFocusedGameObject()
		{
			return this.m_CurrentFocusedGameObject;
		}

		// Token: 0x04000FF2 RID: 4082
		private float m_PrevActionTime;

		// Token: 0x04000FF3 RID: 4083
		private Vector2 m_LastMoveVector;

		// Token: 0x04000FF4 RID: 4084
		private int m_ConsecutiveMoveCount;

		// Token: 0x04000FF5 RID: 4085
		private Vector2 m_LastMousePosition;

		// Token: 0x04000FF6 RID: 4086
		private Vector2 m_MousePosition;

		// Token: 0x04000FF7 RID: 4087
		private GameObject m_CurrentFocusedGameObject;

		// Token: 0x04000FF8 RID: 4088
		[SerializeField]
		private bool m_EnableMouse;

		// Token: 0x04000FF9 RID: 4089
		[SerializeField]
		private string m_HorizontalAxis = "Horizontal";

		// Token: 0x04000FFA RID: 4090
		[SerializeField]
		private string m_VerticalAxis = "Vertical";

		// Token: 0x04000FFB RID: 4091
		[SerializeField]
		private string m_SubmitButton = "Submit";

		// Token: 0x04000FFC RID: 4092
		[SerializeField]
		private string m_CancelButton = "Cancel";

		// Token: 0x04000FFD RID: 4093
		[SerializeField]
		private float m_InputActionsPerSecond = 10f;

		// Token: 0x04000FFE RID: 4094
		[SerializeField]
		private float m_RepeatDelay = 0.5f;

		// Token: 0x04000FFF RID: 4095
		[SerializeField]
		[FormerlySerializedAs("m_AllowActivationOnMobileDevice")]
		private bool m_ForceModuleActive;
	}
}
