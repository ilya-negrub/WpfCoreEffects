using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;

namespace WpfCoreEffects
{
    public class MagnifySmoothEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(MagnifySmoothEffect), 0);
        public static readonly DependencyProperty CenterPointProperty = DependencyProperty.Register("CenterPoint", typeof(Point), typeof(MagnifySmoothEffect), new UIPropertyMetadata(new Point(0.5D, 0.5D), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty InnerRadiusProperty = DependencyProperty.Register("InnerRadius", typeof(double), typeof(MagnifySmoothEffect), new UIPropertyMetadata(((double)(0.2D)), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty OuterRadiusProperty = DependencyProperty.Register("OuterRadius", typeof(double), typeof(MagnifySmoothEffect), new UIPropertyMetadata(((double)(0.4D)), PixelShaderConstantCallback(2)));
        public static readonly DependencyProperty MagnificationAmountProperty = DependencyProperty.Register("MagnificationAmount", typeof(double), typeof(MagnifySmoothEffect), new UIPropertyMetadata(((double)(2D)), PixelShaderConstantCallback(3)));
        public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(MagnifySmoothEffect), new UIPropertyMetadata(((double)(1.5D)), PixelShaderConstantCallback(4)));
        public MagnifySmoothEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("MagnifySmoothEffect.ps", UriKind.Relative);
            //pixelShader.UriSource = new Uri(@"C:\Users\ilya.negrub\source\repos\WpfCoreEffects\WpfCoreEffects\MagnifySmoothEffect.ps", UriKind.Absolute);
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(CenterPointProperty);
            this.UpdateShaderValue(InnerRadiusProperty);
            this.UpdateShaderValue(OuterRadiusProperty);
            this.UpdateShaderValue(MagnificationAmountProperty);
            this.UpdateShaderValue(AspectRatioProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The center point of the magnified region.</summary>
        public Point CenterPoint
        {
            get
            {
                return ((Point)(this.GetValue(CenterPointProperty)));
            }
            set
            {
                this.SetValue(CenterPointProperty, value);
            }
        }
        /// <summary>The inner radius of the magnified region.</summary>
        public double InnerRadius
        {
            get
            {
                return ((double)(this.GetValue(InnerRadiusProperty)));
            }
            set
            {
                this.SetValue(InnerRadiusProperty, value);
            }
        }
        /// <summary>The outer radius of the magnified region.</summary>
        public double OuterRadius
        {
            get
            {
                return ((double)(this.GetValue(OuterRadiusProperty)));
            }
            set
            {
                this.SetValue(OuterRadiusProperty, value);
            }
        }
        /// <summary>The magnification factor.</summary>
        public double MagnificationAmount
        {
            get
            {
                return ((double)(this.GetValue(MagnificationAmountProperty)));
            }
            set
            {
                this.SetValue(MagnificationAmountProperty, value);
            }
        }
        /// <summary>The aspect ratio (width / height) of the input.</summary>
        public double AspectRatio
        {
            get
            {
                return ((double)(this.GetValue(AspectRatioProperty)));
            }
            set
            {
                this.SetValue(AspectRatioProperty, value);
            }
        }
    }
}
