<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:wpf="http://schemas.microsoft.com/winfx/2006/xaml/presentation" xmlns:tk="http://www.qdocuments.net" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" xmlns:d="http://schemas.microsoft.com/expression/blend/2008" mc:Ignorable="d">
  <xsl:output method="xml" version="1.0" encoding="utf-8" indent="yes"/>
  <xsl:template match="/">
    <wpf:StackPanel Orientation="Horizontal" HorizontalAlignment="Right" Margin="0,0,0,10">
      <xsl:apply-templates select="Toolkit/Command"/>
      <xsl:if test="Toolkit/@IncludeCloseCommand = 'true'">
        <wpf:Button Name="Close" Padding="0,10" Margin="10,5,10,5">
          <wpf:StackPanel Orientation="Horizontal" Margin="10, 0, 20, 0">
            <wpf:Image Margin="10,0" Stretch="None">
              <xsl:attribute name="Source">{wpf:Binding Mode=OneTime, Source={tk:Resource Path=Images/png/008删除.png}}</xsl:attribute>
            </wpf:Image>
            <wpf:TextBlock>关闭</wpf:TextBlock>
          </wpf:StackPanel>
        </wpf:Button>
      </xsl:if>
    </wpf:StackPanel>
  </xsl:template>
  <xsl:template match="Command">
    <wpf:Button Name="{@Action}" Padding="0,10" Margin="10, 5, 10, 5">
      <wpf:StackPanel Orientation="Horizontal" Margin="10, 0, 20, 0">
        <xsl:if test="@IconName != ''">
          <wpf:Image Margin="10,0" Stretch="None">
            <xsl:attribute name="Source">{wpf:Binding Mode=OneTime, Source={tk:Resource Path=<xsl:value-of select="@IconName"/>}}</xsl:attribute>
          </wpf:Image>
        </xsl:if>
        <wpf:TextBlock>
          <xsl:value-of select="@DisplayName"/>
        </wpf:TextBlock>
      </wpf:StackPanel>
    </wpf:Button>
  </xsl:template>
</xsl:stylesheet>
