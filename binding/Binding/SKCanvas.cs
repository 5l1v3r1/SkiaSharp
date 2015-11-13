﻿using System;

namespace SkiaSharp
{
	// No dispose, the Canvas is only valid while the Surface is valid.
	public class SKCanvas
	{
		SKSurface s;
		internal IntPtr handle;
		internal SKCanvas (SKSurface s, IntPtr ptr)
		{
			this.s = s;
			handle = ptr;
		}

		public void Save ()
		{
			if (handle == IntPtr.Zero)
				throw new ObjectDisposedException ("SKCanvas");
			SkiaApi.sk_canvas_save (handle);
		}

		public void SaveLayer (SKRect limit, SKPaint paint)
		{
			SkiaApi.sk_canvas_save_layer (handle, ref limit, paint == null ? IntPtr.Zero : paint.handle);
		}

		public void SaveLayer (SKPaint paint)
		{
			SkiaApi.sk_canvas_save_layer (handle, IntPtr.Zero, paint == null ? IntPtr.Zero : paint.handle);
		}

		public void Restore ()
		{
			SkiaApi.sk_canvas_restore (handle);
		}

		public void Translate (float dx, float dy)
		{
			SkiaApi.sk_canvas_translate (handle, dx, dy);
		}

		public void Scale (float sx, float sy)
		{
			SkiaApi.sk_canvas_scale (handle, sx, sy);
		}

		public void RotateDegrees (float degrees)
		{
			SkiaApi.sk_canvas_rotate_degrees (handle, degrees);
		}

		public void RotateRadians (float radians)
		{
			SkiaApi.sk_canvas_rotate_radians (handle, radians);
		}

		public void Skew (float sx, float sy)
		{
			SkiaApi.sk_canvas_skew (handle, sx, sy);
		}

		public void Concat (ref SKMatrix m)
		{
			SkiaApi.sk_canvas_concat (handle, ref m);
		}

		public void ClipRect (SKRect rect)
		{
			SkiaApi.sk_canvas_clip_rect (handle, ref rect);
		}

		public void ClipPath (SKPath path)
		{
			if (path == null)
				throw new ArgumentNullException ("path");
			
			SkiaApi.sk_canvas_clip_path (handle, path.handle);
		}

		public void DrawPaint (SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException ("paint");
			SkiaApi.sk_canvas_draw_paint (handle, paint.handle);
		}

		public void DrawRect (SKRect rect, SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException ("paint");
			SkiaApi.sk_canvas_draw_rect (handle, ref rect, paint.handle);
		}

		public void DrawOval (SKRect rect, SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException ("paint");
			SkiaApi.sk_canvas_draw_oval (handle, ref rect, paint.handle);
		}
		
		public void DrawPath (SKPath path, SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException ("paint");
			if (path == null)
				throw new ArgumentNullException ("path");
			SkiaApi.sk_canvas_draw_path (handle, path.handle, paint.handle);
		}
		
		public void DrawImage (SKPath path, SKImage image, float x, float y, SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException ("paint");
			if (image == null)
				throw new ArgumentNullException ("image");
			if (path == null)
				throw new ArgumentNullException ("path");
			SkiaApi.sk_canvas_draw_image (handle, image.handle, x, y, paint.handle);
		}

		public void DrawImageScaled (SKPath path, SKImage image, SKRect dest, SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException ("paint");
			if (image == null)
				throw new ArgumentNullException ("image");
			if (path == null)
				throw new ArgumentNullException ("path");
			SkiaApi.sk_canvas_draw_image_rect (handle, image.handle, IntPtr.Zero, ref dest, paint.handle);
		}

		public void DrawImageScaled (SKPath path, SKImage image, SKRect source, SKRect dest, SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException ("paint");
			if (image == null)
				throw new ArgumentNullException ("image");
			if (path == null)
				throw new ArgumentNullException ("path");
			SkiaApi.sk_canvas_draw_image_rect (handle, image.handle, ref source, ref dest, paint.handle);
		}

		public void DrawPicture (SKPicture picture, ref SKMatrix matrix, SKPaint paint)
		{
			if (picture == null)
				throw new ArgumentNullException ("picture");
			SkiaApi.sk_canvas_draw_picture (handle, picture.handle, ref matrix, paint == null ? IntPtr.Zero : paint.handle);
		}

		public void DrawPicture (SKPicture picture, SKPaint paint)
		{
			if (picture == null)
				throw new ArgumentNullException ("picture");
			SkiaApi.sk_canvas_draw_picture (handle, picture.handle, IntPtr.Zero, paint == null ? IntPtr.Zero : paint.handle);
		}
		
	}
}
