using System;
using Socotra.UI.Graphics3D;
using Socotra.Util3d;

namespace Socotra.Opt.UI.J3d
{
	// Token: 0x02000110 RID: 272
	public interface StGraphics3D
	{
		// Token: 0x0600153F RID: 5439
		void DrawFigure(Figure figure);

		// Token: 0x06001540 RID: 5440
		void DrawFigure(Figure figure, StTransform trans, bool immidiate = true);

		// Token: 0x06001541 RID: 5441
		void EnableLight(bool b);

		// Token: 0x06001542 RID: 5442
		void EnableSemiTransparent(bool b);

		// Token: 0x06001543 RID: 5443
		void EnableSphereMap(bool b);

		// Token: 0x06001544 RID: 5444
		void EnableToonShader(bool b);

		// Token: 0x06001545 RID: 5445
		void ExecuteCommandList(int[] commandlist);

		// Token: 0x06001546 RID: 5446
		void Flush();

		// Token: 0x06001547 RID: 5447
		void FlushBuffer();

		// Token: 0x06001548 RID: 5448
		void RenderFigure(Figure figure);

		// Token: 0x06001549 RID: 5449
		void RenderPrimitives(PrimitiveArray primitives, int attr, bool isImmediate = false);

		// Token: 0x0600154A RID: 5450
		void RenderPrimitives(PrimitiveArray primitives, int offset, int length, int attr);

		// Token: 0x0600154B RID: 5451
		void SetAmbientLight(int intensity);

		// Token: 0x0600154C RID: 5452
		void SetClipRect3D(int x, int y, int width, int height);

		// Token: 0x0600154D RID: 5453
		void SetDirectionLight(Vector3D direction, int intensity);

		// Token: 0x0600154E RID: 5454
		void SetPerspective(int zNear, int zFar, int angle);

		// Token: 0x0600154F RID: 5455
		void SetPerspective(int zNear, int zFar, int width, int height);

		// Token: 0x06001550 RID: 5456
		void SetPrimitiveTexture(int index);

		// Token: 0x06001551 RID: 5457
		void SetPrimitiveTextureArray(StTexture texture);

		// Token: 0x06001552 RID: 5458
		void SetPrimitiveTextureArray(StTexture[] textures);

		// Token: 0x06001553 RID: 5459
		void SetScreenCenter(int cx, int cy);

		// Token: 0x06001554 RID: 5460
		void SetScreenScale(int sx, int sy);

		// Token: 0x06001555 RID: 5461
		void SetScreenView(int width, int height);

		// Token: 0x06001556 RID: 5462
		void SetSphereTexture(StTexture texture);

		// Token: 0x06001557 RID: 5463
		void SetToonParam(int threshold, int high, int low);

		// Token: 0x06001558 RID: 5464
		void SetViewTrans(AffineTrans at);

		// Token: 0x06001559 RID: 5465
		void SetViewTrans(int index);

		// Token: 0x0600155A RID: 5466
		void SetViewTransArray(AffineTrans[] ats);

		// Token: 0x0600155B RID: 5467
		void SetClipRectFor3D(int originx, int originy, int width, int height);

		// Token: 0x0600155C RID: 5468
		void RenderObject3D(DrawableObject3D obj, StTransform transform);

		// Token: 0x0600155D RID: 5469
		void ResetLights();

		// Token: 0x0600155E RID: 5470
		void AddLight(StLight light, StTransform transform);

		// Token: 0x0600155F RID: 5471
		void SetPerspectiveView(float zNear, float zFar, float angle);

		// Token: 0x06001560 RID: 5472
		void SetPerspectiveView(float zNear, float zFar, int width, int height);

		// Token: 0x06001561 RID: 5473
		void SetParallelView(int width, int height);

		// Token: 0x06001562 RID: 5474
		void SetTransform(StTransform t);

		// Token: 0x06001563 RID: 5475
		void SetCameraPosition(StTransform t);
	}
}
