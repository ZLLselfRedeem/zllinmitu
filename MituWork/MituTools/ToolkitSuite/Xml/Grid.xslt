<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" xmlns:d="http://schemas.microsoft.com/expression/blend/2008" xmlns:tk="http://www.qdocuments.net" xmlns:wpf="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
  <xsl:output method="xml" version="1.0" encoding="utf-8" indent="yes"/>
  <xsl:template match="/">
    <xsl:for-each select="Toolkit">
      <wpf:Grid Margin="40, 40, 40, 40" tk:ControlHelper.DataModuleType="{@DataModuleType}" mc:Ignorable="d" d:DesignHeight="300" d:DesignWidth="300">
        <wpf:Grid.RowDefinitions>
          <xsl:call-template name="RowDef">
            <xsl:with-param name="Count" select="@RowCount"/>
          </xsl:call-template>
        </wpf:Grid.RowDefinitions>
        <wpf:Grid.ColumnDefinitions>
          <xsl:call-template name="ColumnDef">
            <xsl:with-param name="Count" select="@ColumnCount"/>
          </xsl:call-template>
        </wpf:Grid.ColumnDefinitions>
        <xsl:apply-templates select="Field"/>
      </wpf:Grid>
    </xsl:for-each>
  </xsl:template>
  <xsl:template name="RowDef">
    <xsl:param name="Count"/>
    <xsl:param name="Index" select="0"/>
    <xsl:if test="$Index &lt; $Count">
      <wpf:RowDefinition Height="Auto"/>
      <xsl:call-template name="RowDef">
        <xsl:with-param name="Count" select="$Count"/>
        <xsl:with-param name="Index" select="$Index + 1"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template name="ColumnDef">
    <xsl:param name="Count"/>
    <xsl:param name="Index" select="0"/>
    <xsl:if test="$Index &lt; $Count">
      <wpf:ColumnDefinition Width="*"/>
      <wpf:ColumnDefinition Width="3*"/>
      <xsl:call-template name="ColumnDef">
        <xsl:with-param name="Count" select="$Count"/>
        <xsl:with-param name="Index" select="$Index + 1"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="Field">
    <xsl:call-template name="TextBlock"/>
    <xsl:apply-templates select="." mode="Ctrl"/>
  </xsl:template>
  <xsl:template match="Field[WpfCtrl/@CtrlType = 'Combo']" mode='Ctrl'>
    <wpf:ComboBox>
      <xsl:call-template name="GridPosition"/>
      <xsl:attribute name="tk:ControlHelper.CodeTable">{tk:CodeTable RegName=<xsl:value-of select="Decoder/@RegName"/>}</xsl:attribute>
      <xsl:attribute name="SelectedValue">{wpf:Binding Path=<xsl:value-of select="FieldName"/>, Mode=TwoWay}</xsl:attribute>
    </wpf:ComboBox>
  </xsl:template>
  <xsl:template match="Field[WpfCtrl/@CtrlType = 'Text']" mode='Ctrl'>
    <wpf:TextBox>
      <xsl:call-template name="GridPosition"/>
      <xsl:attribute name="Text">{wpf:Binding Path=<xsl:value-of select="FieldName"/>}</xsl:attribute>
    </wpf:TextBox>
  </xsl:template>
  <xsl:template match="Field[WpfCtrl/@CtrlType = 'Label']" mode='Ctrl'>
    <wpf:TextBlock Padding="0, 5, 0, 5">
      <xsl:call-template name="GridPosition"/>
      <xsl:attribute name="Text">{wpf:Binding Path=<xsl:value-of select="FieldName"/>,  StringFormat=<xsl:value-of select="Display/@Format"/> ,TargetNullValue =<xsl:value-of select="DisplayName"/> }</xsl:attribute>
    </wpf:TextBlock>
  </xsl:template>
  <xsl:template name="TextBlock">
    <wpf:TextBlock Padding="0, 5, 0, 5" Text="{DisplayName}" wpf:Grid.Row="{@Row}" wpf:Grid.Column="{@Column * 2}" TextAlignment="Right"/>
  </xsl:template>
  <xsl:template name="GridPosition">
    <xsl:attribute name="wpf:Grid.Row">
      <xsl:value-of select="@Row"/>
    </xsl:attribute>
    <xsl:attribute name="wpf:Grid.Column">
      <xsl:value-of select="@Column * 2 + 1"/>
    </xsl:attribute>
    <xsl:if test="@Column != 1">
      <xsl:attribute name="wpf:Grid.ColumnSpan">
        <xsl:value-of select="@ColumnSpan * 2 - 1"/>
      </xsl:attribute>
    </xsl:if>
    <xsl:attribute name="Name">
      <xsl:value-of select="FieldName"/>
    </xsl:attribute>
  </xsl:template>
</xsl:stylesheet>
