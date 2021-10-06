
namespace UDS_Decoder
{
    partial class uds_decoder
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_connect = new System.Windows.Forms.Button();
            this.selector_com_port = new System.Windows.Forms.ComboBox();
            this.tb_mult = new System.Windows.Forms.TextBox();
            this.cb_byte0 = new System.Windows.Forms.CheckBox();
            this.tb_byte0 = new System.Windows.Forms.TextBox();
            this.tb_byte1 = new System.Windows.Forms.TextBox();
            this.cb_byte1 = new System.Windows.Forms.CheckBox();
            this.tb_byte2 = new System.Windows.Forms.TextBox();
            this.cb_byte2 = new System.Windows.Forms.CheckBox();
            this.tb_byte3 = new System.Windows.Forms.TextBox();
            this.cb_byte3 = new System.Windows.Forms.CheckBox();
            this.tb_byte4 = new System.Windows.Forms.TextBox();
            this.cb_byte4 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_add = new System.Windows.Forms.TextBox();
            this.tb_val = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_div = new System.Windows.Forms.TextBox();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.btn_com_port_refresh = new System.Windows.Forms.Button();
            this.cb_signed = new System.Windows.Forms.CheckBox();
            this.tb_br0 = new System.Windows.Forms.TextBox();
            this.tb_br1 = new System.Windows.Forms.TextBox();
            this.lab_msg_counter = new System.Windows.Forms.Label();
            this.tb_byte5 = new System.Windows.Forms.TextBox();
            this.cb_byte5 = new System.Windows.Forms.CheckBox();
            this.tb_byte6 = new System.Windows.Forms.TextBox();
            this.cb_byte6 = new System.Windows.Forms.CheckBox();
            this.tb_byte7 = new System.Windows.Forms.TextBox();
            this.cb_byte7 = new System.Windows.Forms.CheckBox();
            this.tb_byte8 = new System.Windows.Forms.TextBox();
            this.cb_byte8 = new System.Windows.Forms.CheckBox();
            this.tb_byte9 = new System.Windows.Forms.TextBox();
            this.cb_byte9 = new System.Windows.Forms.CheckBox();
            this.tb_byte10 = new System.Windows.Forms.TextBox();
            this.cb_byte10 = new System.Windows.Forms.CheckBox();
            this.tb_byte11 = new System.Windows.Forms.TextBox();
            this.cb_byte11 = new System.Windows.Forms.CheckBox();
            this.tb_byte14 = new System.Windows.Forms.TextBox();
            this.cb_byte14 = new System.Windows.Forms.CheckBox();
            this.tb_byte13 = new System.Windows.Forms.TextBox();
            this.cb_byte13 = new System.Windows.Forms.CheckBox();
            this.tb_byte12 = new System.Windows.Forms.TextBox();
            this.cb_byte12 = new System.Windows.Forms.CheckBox();
            this.tb_act_value = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_factor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_byte15 = new System.Windows.Forms.TextBox();
            this.cb_byte15 = new System.Windows.Forms.CheckBox();
            this.tb_factor2 = new System.Windows.Forms.TextBox();
            this.lab_startbit = new System.Windows.Forms.Label();
            this.lab_length = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_ax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_ay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_bx = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_by = new System.Windows.Forms.TextBox();
            this.btn_set_ax = new System.Windows.Forms.Button();
            this.btn_set_ay = new System.Windows.Forms.Button();
            this.btn_set_bx = new System.Windows.Forms.Button();
            this.btn_set_by = new System.Windows.Forms.Button();
            this.tb_ssr_t = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_ssr_m = new System.Windows.Forms.TextBox();
            this.tb_settingsstring = new System.Windows.Forms.TextBox();
            this.tb_bitmask = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_abc_bit = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_abc_int = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_abc_in = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cb_isFloat = new System.Windows.Forms.CheckBox();
            this.lab_value_big = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(108, 12);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // selector_com_port
            // 
            this.selector_com_port.FormattingEnabled = true;
            this.selector_com_port.Location = new System.Drawing.Point(12, 12);
            this.selector_com_port.Name = "selector_com_port";
            this.selector_com_port.Size = new System.Drawing.Size(66, 21);
            this.selector_com_port.TabIndex = 1;
            // 
            // tb_mult
            // 
            this.tb_mult.Location = new System.Drawing.Point(34, 116);
            this.tb_mult.Name = "tb_mult";
            this.tb_mult.Size = new System.Drawing.Size(72, 20);
            this.tb_mult.TabIndex = 2;
            this.tb_mult.Text = "1";
            // 
            // cb_byte0
            // 
            this.cb_byte0.AutoSize = true;
            this.cb_byte0.Location = new System.Drawing.Point(170, 51);
            this.cb_byte0.Name = "cb_byte0";
            this.cb_byte0.Size = new System.Drawing.Size(35, 17);
            this.cb_byte0.TabIndex = 3;
            this.cb_byte0.Text = " 0";
            this.cb_byte0.UseVisualStyleBackColor = true;
            this.cb_byte0.CheckedChanged += new System.EventHandler(this.cb_byte0_CheckedChanged);
            // 
            // tb_byte0
            // 
            this.tb_byte0.Location = new System.Drawing.Point(170, 25);
            this.tb_byte0.Name = "tb_byte0";
            this.tb_byte0.Size = new System.Drawing.Size(36, 20);
            this.tb_byte0.TabIndex = 4;
            // 
            // tb_byte1
            // 
            this.tb_byte1.Location = new System.Drawing.Point(211, 25);
            this.tb_byte1.Name = "tb_byte1";
            this.tb_byte1.Size = new System.Drawing.Size(36, 20);
            this.tb_byte1.TabIndex = 6;
            // 
            // cb_byte1
            // 
            this.cb_byte1.AutoSize = true;
            this.cb_byte1.Location = new System.Drawing.Point(211, 51);
            this.cb_byte1.Name = "cb_byte1";
            this.cb_byte1.Size = new System.Drawing.Size(32, 17);
            this.cb_byte1.TabIndex = 5;
            this.cb_byte1.Text = "1";
            this.cb_byte1.UseVisualStyleBackColor = true;
            this.cb_byte1.CheckedChanged += new System.EventHandler(this.cb_byte1_CheckedChanged);
            // 
            // tb_byte2
            // 
            this.tb_byte2.Location = new System.Drawing.Point(252, 25);
            this.tb_byte2.Name = "tb_byte2";
            this.tb_byte2.Size = new System.Drawing.Size(36, 20);
            this.tb_byte2.TabIndex = 8;
            // 
            // cb_byte2
            // 
            this.cb_byte2.AutoSize = true;
            this.cb_byte2.Location = new System.Drawing.Point(252, 51);
            this.cb_byte2.Name = "cb_byte2";
            this.cb_byte2.Size = new System.Drawing.Size(35, 17);
            this.cb_byte2.TabIndex = 7;
            this.cb_byte2.Text = " 2";
            this.cb_byte2.UseVisualStyleBackColor = true;
            this.cb_byte2.CheckedChanged += new System.EventHandler(this.cb_byte2_CheckedChanged);
            // 
            // tb_byte3
            // 
            this.tb_byte3.Location = new System.Drawing.Point(293, 25);
            this.tb_byte3.Name = "tb_byte3";
            this.tb_byte3.Size = new System.Drawing.Size(36, 20);
            this.tb_byte3.TabIndex = 10;
            // 
            // cb_byte3
            // 
            this.cb_byte3.AutoSize = true;
            this.cb_byte3.Location = new System.Drawing.Point(293, 51);
            this.cb_byte3.Name = "cb_byte3";
            this.cb_byte3.Size = new System.Drawing.Size(35, 17);
            this.cb_byte3.TabIndex = 9;
            this.cb_byte3.Text = " 3";
            this.cb_byte3.UseVisualStyleBackColor = true;
            this.cb_byte3.CheckedChanged += new System.EventHandler(this.cb_byte3_CheckedChanged);
            // 
            // tb_byte4
            // 
            this.tb_byte4.Location = new System.Drawing.Point(334, 25);
            this.tb_byte4.Name = "tb_byte4";
            this.tb_byte4.Size = new System.Drawing.Size(36, 20);
            this.tb_byte4.TabIndex = 12;
            // 
            // cb_byte4
            // 
            this.cb_byte4.AutoSize = true;
            this.cb_byte4.Location = new System.Drawing.Point(334, 51);
            this.cb_byte4.Name = "cb_byte4";
            this.cb_byte4.Size = new System.Drawing.Size(35, 17);
            this.cb_byte4.TabIndex = 11;
            this.cb_byte4.Text = " 4";
            this.cb_byte4.UseVisualStyleBackColor = true;
            this.cb_byte4.CheckedChanged += new System.EventHandler(this.cb_byte4_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mult";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Add";
            // 
            // tb_add
            // 
            this.tb_add.Location = new System.Drawing.Point(34, 90);
            this.tb_add.Name = "tb_add";
            this.tb_add.Size = new System.Drawing.Size(72, 20);
            this.tb_add.TabIndex = 14;
            this.tb_add.Text = "0";
            // 
            // tb_val
            // 
            this.tb_val.Location = new System.Drawing.Point(127, 116);
            this.tb_val.Name = "tb_val";
            this.tb_val.Size = new System.Drawing.Size(98, 20);
            this.tb_val.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Div";
            // 
            // tb_div
            // 
            this.tb_div.Location = new System.Drawing.Point(33, 142);
            this.tb_div.Name = "tb_div";
            this.tb_div.Size = new System.Drawing.Size(73, 20);
            this.tb_div.TabIndex = 17;
            this.tb_div.Text = "1";
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(9, 25);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(77, 20);
            this.tb_id.TabIndex = 19;
            // 
            // btn_com_port_refresh
            // 
            this.btn_com_port_refresh.Location = new System.Drawing.Point(84, 12);
            this.btn_com_port_refresh.Name = "btn_com_port_refresh";
            this.btn_com_port_refresh.Size = new System.Drawing.Size(18, 23);
            this.btn_com_port_refresh.TabIndex = 20;
            this.btn_com_port_refresh.Text = "R";
            this.btn_com_port_refresh.UseVisualStyleBackColor = true;
            this.btn_com_port_refresh.Click += new System.EventHandler(this.btn_com_port_refresh_Click);
            // 
            // cb_signed
            // 
            this.cb_signed.AutoSize = true;
            this.cb_signed.Location = new System.Drawing.Point(124, 89);
            this.cb_signed.Name = "cb_signed";
            this.cb_signed.Size = new System.Drawing.Size(59, 17);
            this.cb_signed.TabIndex = 21;
            this.cb_signed.Text = "Signed";
            this.cb_signed.UseVisualStyleBackColor = true;
            // 
            // tb_br0
            // 
            this.tb_br0.Location = new System.Drawing.Point(92, 25);
            this.tb_br0.Name = "tb_br0";
            this.tb_br0.Size = new System.Drawing.Size(27, 20);
            this.tb_br0.TabIndex = 22;
            // 
            // tb_br1
            // 
            this.tb_br1.Location = new System.Drawing.Point(125, 25);
            this.tb_br1.Name = "tb_br1";
            this.tb_br1.Size = new System.Drawing.Size(27, 20);
            this.tb_br1.TabIndex = 23;
            // 
            // lab_msg_counter
            // 
            this.lab_msg_counter.AutoSize = true;
            this.lab_msg_counter.Location = new System.Drawing.Point(205, 17);
            this.lab_msg_counter.Name = "lab_msg_counter";
            this.lab_msg_counter.Size = new System.Drawing.Size(13, 13);
            this.lab_msg_counter.TabIndex = 24;
            this.lab_msg_counter.Text = "0";
            // 
            // tb_byte5
            // 
            this.tb_byte5.Location = new System.Drawing.Point(376, 25);
            this.tb_byte5.Name = "tb_byte5";
            this.tb_byte5.Size = new System.Drawing.Size(36, 20);
            this.tb_byte5.TabIndex = 26;
            // 
            // cb_byte5
            // 
            this.cb_byte5.AutoSize = true;
            this.cb_byte5.Location = new System.Drawing.Point(376, 51);
            this.cb_byte5.Name = "cb_byte5";
            this.cb_byte5.Size = new System.Drawing.Size(35, 17);
            this.cb_byte5.TabIndex = 25;
            this.cb_byte5.Text = " 5";
            this.cb_byte5.UseVisualStyleBackColor = true;
            this.cb_byte5.CheckedChanged += new System.EventHandler(this.cb_byte5_CheckedChanged);
            // 
            // tb_byte6
            // 
            this.tb_byte6.Location = new System.Drawing.Point(418, 25);
            this.tb_byte6.Name = "tb_byte6";
            this.tb_byte6.Size = new System.Drawing.Size(36, 20);
            this.tb_byte6.TabIndex = 28;
            // 
            // cb_byte6
            // 
            this.cb_byte6.AutoSize = true;
            this.cb_byte6.Location = new System.Drawing.Point(418, 51);
            this.cb_byte6.Name = "cb_byte6";
            this.cb_byte6.Size = new System.Drawing.Size(35, 17);
            this.cb_byte6.TabIndex = 27;
            this.cb_byte6.Text = " 6";
            this.cb_byte6.UseVisualStyleBackColor = true;
            this.cb_byte6.CheckedChanged += new System.EventHandler(this.cb_byte6_CheckedChanged);
            // 
            // tb_byte7
            // 
            this.tb_byte7.Location = new System.Drawing.Point(460, 25);
            this.tb_byte7.Name = "tb_byte7";
            this.tb_byte7.Size = new System.Drawing.Size(36, 20);
            this.tb_byte7.TabIndex = 30;
            // 
            // cb_byte7
            // 
            this.cb_byte7.AutoSize = true;
            this.cb_byte7.Location = new System.Drawing.Point(460, 51);
            this.cb_byte7.Name = "cb_byte7";
            this.cb_byte7.Size = new System.Drawing.Size(35, 17);
            this.cb_byte7.TabIndex = 29;
            this.cb_byte7.Text = " 7";
            this.cb_byte7.UseVisualStyleBackColor = true;
            this.cb_byte7.CheckedChanged += new System.EventHandler(this.cb_byte7_CheckedChanged);
            // 
            // tb_byte8
            // 
            this.tb_byte8.Location = new System.Drawing.Point(502, 25);
            this.tb_byte8.Name = "tb_byte8";
            this.tb_byte8.Size = new System.Drawing.Size(36, 20);
            this.tb_byte8.TabIndex = 32;
            // 
            // cb_byte8
            // 
            this.cb_byte8.AutoSize = true;
            this.cb_byte8.Location = new System.Drawing.Point(502, 51);
            this.cb_byte8.Name = "cb_byte8";
            this.cb_byte8.Size = new System.Drawing.Size(35, 17);
            this.cb_byte8.TabIndex = 31;
            this.cb_byte8.Text = " 8";
            this.cb_byte8.UseVisualStyleBackColor = true;
            this.cb_byte8.CheckedChanged += new System.EventHandler(this.cb_byte8_CheckedChanged);
            // 
            // tb_byte9
            // 
            this.tb_byte9.Location = new System.Drawing.Point(544, 25);
            this.tb_byte9.Name = "tb_byte9";
            this.tb_byte9.Size = new System.Drawing.Size(36, 20);
            this.tb_byte9.TabIndex = 34;
            // 
            // cb_byte9
            // 
            this.cb_byte9.AutoSize = true;
            this.cb_byte9.Location = new System.Drawing.Point(544, 51);
            this.cb_byte9.Name = "cb_byte9";
            this.cb_byte9.Size = new System.Drawing.Size(32, 17);
            this.cb_byte9.TabIndex = 33;
            this.cb_byte9.Text = "9";
            this.cb_byte9.UseVisualStyleBackColor = true;
            this.cb_byte9.CheckedChanged += new System.EventHandler(this.cb_byte9_CheckedChanged);
            // 
            // tb_byte10
            // 
            this.tb_byte10.Location = new System.Drawing.Point(586, 25);
            this.tb_byte10.Name = "tb_byte10";
            this.tb_byte10.Size = new System.Drawing.Size(36, 20);
            this.tb_byte10.TabIndex = 36;
            // 
            // cb_byte10
            // 
            this.cb_byte10.AutoSize = true;
            this.cb_byte10.Location = new System.Drawing.Point(586, 51);
            this.cb_byte10.Name = "cb_byte10";
            this.cb_byte10.Size = new System.Drawing.Size(38, 17);
            this.cb_byte10.TabIndex = 35;
            this.cb_byte10.Text = "10";
            this.cb_byte10.UseVisualStyleBackColor = true;
            this.cb_byte10.CheckedChanged += new System.EventHandler(this.cb_byte10_CheckedChanged);
            // 
            // tb_byte11
            // 
            this.tb_byte11.Location = new System.Drawing.Point(628, 25);
            this.tb_byte11.Name = "tb_byte11";
            this.tb_byte11.Size = new System.Drawing.Size(36, 20);
            this.tb_byte11.TabIndex = 38;
            // 
            // cb_byte11
            // 
            this.cb_byte11.AutoSize = true;
            this.cb_byte11.Location = new System.Drawing.Point(628, 51);
            this.cb_byte11.Name = "cb_byte11";
            this.cb_byte11.Size = new System.Drawing.Size(38, 17);
            this.cb_byte11.TabIndex = 37;
            this.cb_byte11.Text = "11";
            this.cb_byte11.UseVisualStyleBackColor = true;
            this.cb_byte11.CheckedChanged += new System.EventHandler(this.cb_byte11_CheckedChanged);
            // 
            // tb_byte14
            // 
            this.tb_byte14.Location = new System.Drawing.Point(755, 25);
            this.tb_byte14.Name = "tb_byte14";
            this.tb_byte14.Size = new System.Drawing.Size(36, 20);
            this.tb_byte14.TabIndex = 44;
            // 
            // cb_byte14
            // 
            this.cb_byte14.AutoSize = true;
            this.cb_byte14.Location = new System.Drawing.Point(755, 51);
            this.cb_byte14.Name = "cb_byte14";
            this.cb_byte14.Size = new System.Drawing.Size(38, 17);
            this.cb_byte14.TabIndex = 43;
            this.cb_byte14.Text = "14";
            this.cb_byte14.UseVisualStyleBackColor = true;
            this.cb_byte14.CheckedChanged += new System.EventHandler(this.cb_byte14_CheckedChanged);
            // 
            // tb_byte13
            // 
            this.tb_byte13.Location = new System.Drawing.Point(713, 25);
            this.tb_byte13.Name = "tb_byte13";
            this.tb_byte13.Size = new System.Drawing.Size(36, 20);
            this.tb_byte13.TabIndex = 42;
            // 
            // cb_byte13
            // 
            this.cb_byte13.AutoSize = true;
            this.cb_byte13.Location = new System.Drawing.Point(713, 51);
            this.cb_byte13.Name = "cb_byte13";
            this.cb_byte13.Size = new System.Drawing.Size(38, 17);
            this.cb_byte13.TabIndex = 41;
            this.cb_byte13.Text = "13";
            this.cb_byte13.UseVisualStyleBackColor = true;
            this.cb_byte13.CheckedChanged += new System.EventHandler(this.cb_byte13_CheckedChanged);
            // 
            // tb_byte12
            // 
            this.tb_byte12.Location = new System.Drawing.Point(671, 25);
            this.tb_byte12.Name = "tb_byte12";
            this.tb_byte12.Size = new System.Drawing.Size(36, 20);
            this.tb_byte12.TabIndex = 40;
            // 
            // cb_byte12
            // 
            this.cb_byte12.AutoSize = true;
            this.cb_byte12.Location = new System.Drawing.Point(671, 51);
            this.cb_byte12.Name = "cb_byte12";
            this.cb_byte12.Size = new System.Drawing.Size(38, 17);
            this.cb_byte12.TabIndex = 39;
            this.cb_byte12.Text = "12";
            this.cb_byte12.UseVisualStyleBackColor = true;
            this.cb_byte12.CheckedChanged += new System.EventHandler(this.cb_byte12_CheckedChanged);
            // 
            // tb_act_value
            // 
            this.tb_act_value.Location = new System.Drawing.Point(164, 164);
            this.tb_act_value.Name = "tb_act_value";
            this.tb_act_value.Size = new System.Drawing.Size(77, 20);
            this.tb_act_value.TabIndex = 45;
            this.tb_act_value.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Actual Value";
            // 
            // tb_factor
            // 
            this.tb_factor.Enabled = false;
            this.tb_factor.Location = new System.Drawing.Point(164, 191);
            this.tb_factor.Name = "tb_factor";
            this.tb_factor.Size = new System.Drawing.Size(77, 20);
            this.tb_factor.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Factor";
            // 
            // tb_byte15
            // 
            this.tb_byte15.Location = new System.Drawing.Point(798, 25);
            this.tb_byte15.Name = "tb_byte15";
            this.tb_byte15.Size = new System.Drawing.Size(36, 20);
            this.tb_byte15.TabIndex = 50;
            // 
            // cb_byte15
            // 
            this.cb_byte15.AutoSize = true;
            this.cb_byte15.Location = new System.Drawing.Point(798, 51);
            this.cb_byte15.Name = "cb_byte15";
            this.cb_byte15.Size = new System.Drawing.Size(38, 17);
            this.cb_byte15.TabIndex = 49;
            this.cb_byte15.Text = "15";
            this.cb_byte15.UseVisualStyleBackColor = true;
            this.cb_byte15.CheckedChanged += new System.EventHandler(this.cb_byte15_CheckedChanged);
            // 
            // tb_factor2
            // 
            this.tb_factor2.Enabled = false;
            this.tb_factor2.Location = new System.Drawing.Point(250, 191);
            this.tb_factor2.Name = "tb_factor2";
            this.tb_factor2.Size = new System.Drawing.Size(77, 20);
            this.tb_factor2.TabIndex = 51;
            // 
            // lab_startbit
            // 
            this.lab_startbit.AutoSize = true;
            this.lab_startbit.Location = new System.Drawing.Point(577, 98);
            this.lab_startbit.Name = "lab_startbit";
            this.lab_startbit.Size = new System.Drawing.Size(43, 13);
            this.lab_startbit.TabIndex = 52;
            this.lab_startbit.Text = "Startbit:";
            // 
            // lab_length
            // 
            this.lab_length.AutoSize = true;
            this.lab_length.Location = new System.Drawing.Point(577, 119);
            this.lab_length.Name = "lab_length";
            this.lab_length.Size = new System.Drawing.Size(43, 13);
            this.lab_length.TabIndex = 53;
            this.lab_length.Text = "Length:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(370, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "A x";
            // 
            // tb_ax
            // 
            this.tb_ax.Location = new System.Drawing.Point(398, 88);
            this.tb_ax.Name = "tb_ax";
            this.tb_ax.Size = new System.Drawing.Size(77, 20);
            this.tb_ax.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(370, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "A y";
            // 
            // tb_ay
            // 
            this.tb_ay.Location = new System.Drawing.Point(398, 114);
            this.tb_ay.Name = "tb_ay";
            this.tb_ay.Size = new System.Drawing.Size(77, 20);
            this.tb_ay.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(370, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "B x";
            // 
            // tb_bx
            // 
            this.tb_bx.Location = new System.Drawing.Point(398, 140);
            this.tb_bx.Name = "tb_bx";
            this.tb_bx.Size = new System.Drawing.Size(77, 20);
            this.tb_bx.TabIndex = 58;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(370, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 61;
            this.label9.Text = "B y";
            // 
            // tb_by
            // 
            this.tb_by.Location = new System.Drawing.Point(398, 166);
            this.tb_by.Name = "tb_by";
            this.tb_by.Size = new System.Drawing.Size(77, 20);
            this.tb_by.TabIndex = 60;
            // 
            // btn_set_ax
            // 
            this.btn_set_ax.Location = new System.Drawing.Point(481, 86);
            this.btn_set_ax.Name = "btn_set_ax";
            this.btn_set_ax.Size = new System.Drawing.Size(33, 23);
            this.btn_set_ax.TabIndex = 62;
            this.btn_set_ax.Text = "Set";
            this.btn_set_ax.UseVisualStyleBackColor = true;
            this.btn_set_ax.Click += new System.EventHandler(this.btn_set_ax_Click);
            // 
            // btn_set_ay
            // 
            this.btn_set_ay.Location = new System.Drawing.Point(481, 114);
            this.btn_set_ay.Name = "btn_set_ay";
            this.btn_set_ay.Size = new System.Drawing.Size(33, 23);
            this.btn_set_ay.TabIndex = 63;
            this.btn_set_ay.Text = "Set";
            this.btn_set_ay.UseVisualStyleBackColor = true;
            this.btn_set_ay.Click += new System.EventHandler(this.btn_set_ay_Click);
            // 
            // btn_set_bx
            // 
            this.btn_set_bx.Location = new System.Drawing.Point(481, 138);
            this.btn_set_bx.Name = "btn_set_bx";
            this.btn_set_bx.Size = new System.Drawing.Size(33, 23);
            this.btn_set_bx.TabIndex = 64;
            this.btn_set_bx.Text = "Set";
            this.btn_set_bx.UseVisualStyleBackColor = true;
            this.btn_set_bx.Click += new System.EventHandler(this.btn_set_bx_Click);
            // 
            // btn_set_by
            // 
            this.btn_set_by.Location = new System.Drawing.Point(481, 164);
            this.btn_set_by.Name = "btn_set_by";
            this.btn_set_by.Size = new System.Drawing.Size(33, 23);
            this.btn_set_by.TabIndex = 65;
            this.btn_set_by.Text = "Set";
            this.btn_set_by.UseVisualStyleBackColor = true;
            this.btn_set_by.Click += new System.EventHandler(this.btn_set_by_Click);
            // 
            // tb_ssr_t
            // 
            this.tb_ssr_t.Enabled = false;
            this.tb_ssr_t.Location = new System.Drawing.Point(484, 194);
            this.tb_ssr_t.Name = "tb_ssr_t";
            this.tb_ssr_t.Size = new System.Drawing.Size(77, 20);
            this.tb_ssr_t.TabIndex = 68;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(355, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 67;
            this.label10.Text = "Factor";
            // 
            // tb_ssr_m
            // 
            this.tb_ssr_m.Enabled = false;
            this.tb_ssr_m.Location = new System.Drawing.Point(398, 194);
            this.tb_ssr_m.Name = "tb_ssr_m";
            this.tb_ssr_m.Size = new System.Drawing.Size(77, 20);
            this.tb_ssr_m.TabIndex = 66;
            // 
            // tb_settingsstring
            // 
            this.tb_settingsstring.Location = new System.Drawing.Point(264, 14);
            this.tb_settingsstring.Name = "tb_settingsstring";
            this.tb_settingsstring.Size = new System.Drawing.Size(582, 20);
            this.tb_settingsstring.TabIndex = 69;
            // 
            // tb_bitmask
            // 
            this.tb_bitmask.Location = new System.Drawing.Point(52, 51);
            this.tb_bitmask.Name = "tb_bitmask";
            this.tb_bitmask.Size = new System.Drawing.Size(108, 20);
            this.tb_bitmask.TabIndex = 70;
            this.tb_bitmask.Text = "0x00";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 71;
            this.label11.Text = "Bitmask";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_isFloat);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tb_bitmask);
            this.groupBox1.Controls.Add(this.tb_ssr_t);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tb_ssr_m);
            this.groupBox1.Controls.Add(this.btn_set_by);
            this.groupBox1.Controls.Add(this.btn_set_bx);
            this.groupBox1.Controls.Add(this.btn_set_ay);
            this.groupBox1.Controls.Add(this.btn_set_ax);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tb_by);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tb_bx);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tb_ay);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tb_ax);
            this.groupBox1.Controls.Add(this.lab_length);
            this.groupBox1.Controls.Add(this.lab_startbit);
            this.groupBox1.Controls.Add(this.tb_factor2);
            this.groupBox1.Controls.Add(this.tb_byte15);
            this.groupBox1.Controls.Add(this.cb_byte15);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tb_factor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_act_value);
            this.groupBox1.Controls.Add(this.tb_byte14);
            this.groupBox1.Controls.Add(this.cb_byte14);
            this.groupBox1.Controls.Add(this.tb_byte13);
            this.groupBox1.Controls.Add(this.cb_byte13);
            this.groupBox1.Controls.Add(this.tb_byte12);
            this.groupBox1.Controls.Add(this.cb_byte12);
            this.groupBox1.Controls.Add(this.tb_byte11);
            this.groupBox1.Controls.Add(this.cb_byte11);
            this.groupBox1.Controls.Add(this.tb_byte10);
            this.groupBox1.Controls.Add(this.cb_byte10);
            this.groupBox1.Controls.Add(this.tb_byte9);
            this.groupBox1.Controls.Add(this.cb_byte9);
            this.groupBox1.Controls.Add(this.tb_byte8);
            this.groupBox1.Controls.Add(this.cb_byte8);
            this.groupBox1.Controls.Add(this.tb_byte7);
            this.groupBox1.Controls.Add(this.cb_byte7);
            this.groupBox1.Controls.Add(this.tb_byte6);
            this.groupBox1.Controls.Add(this.cb_byte6);
            this.groupBox1.Controls.Add(this.tb_byte5);
            this.groupBox1.Controls.Add(this.cb_byte5);
            this.groupBox1.Controls.Add(this.tb_br1);
            this.groupBox1.Controls.Add(this.tb_br0);
            this.groupBox1.Controls.Add(this.cb_signed);
            this.groupBox1.Controls.Add(this.tb_id);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_div);
            this.groupBox1.Controls.Add(this.tb_val);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_add);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_byte4);
            this.groupBox1.Controls.Add(this.cb_byte4);
            this.groupBox1.Controls.Add(this.tb_byte3);
            this.groupBox1.Controls.Add(this.cb_byte3);
            this.groupBox1.Controls.Add(this.tb_byte2);
            this.groupBox1.Controls.Add(this.cb_byte2);
            this.groupBox1.Controls.Add(this.tb_byte1);
            this.groupBox1.Controls.Add(this.cb_byte1);
            this.groupBox1.Controls.Add(this.tb_byte0);
            this.groupBox1.Controls.Add(this.cb_byte0);
            this.groupBox1.Controls.Add(this.tb_mult);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(855, 226);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VCDS Decoder";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_abc_bit);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tb_abc_int);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tb_abc_in);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(854, 77);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Torque PID Decoder";
            // 
            // tb_abc_bit
            // 
            this.tb_abc_bit.Location = new System.Drawing.Point(170, 45);
            this.tb_abc_bit.Name = "tb_abc_bit";
            this.tb_abc_bit.Size = new System.Drawing.Size(42, 20);
            this.tb_abc_bit.TabIndex = 75;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(107, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 74;
            this.label13.Text = "=";
            // 
            // tb_abc_int
            // 
            this.tb_abc_int.Location = new System.Drawing.Point(122, 45);
            this.tb_abc_int.Name = "tb_abc_int";
            this.tb_abc_int.Size = new System.Drawing.Size(42, 20);
            this.tb_abc_int.TabIndex = 73;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 72;
            this.label12.Text = "ABC to Int";
            // 
            // tb_abc_in
            // 
            this.tb_abc_in.Location = new System.Drawing.Point(64, 45);
            this.tb_abc_in.Name = "tb_abc_in";
            this.tb_abc_in.Size = new System.Drawing.Size(42, 20);
            this.tb_abc_in.TabIndex = 21;
            this.tb_abc_in.TextChanged += new System.EventHandler(this.tb_abc_in_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(716, 20);
            this.textBox1.TabIndex = 20;
            // 
            // cb_isFloat
            // 
            this.cb_isFloat.AutoSize = true;
            this.cb_isFloat.Location = new System.Drawing.Point(189, 89);
            this.cb_isFloat.Name = "cb_isFloat";
            this.cb_isFloat.Size = new System.Drawing.Size(49, 17);
            this.cb_isFloat.TabIndex = 72;
            this.cb_isFloat.Text = "Float";
            this.cb_isFloat.UseVisualStyleBackColor = true;
            // 
            // lab_value_big
            // 
            this.lab_value_big.AutoSize = true;
            this.lab_value_big.Font = new System.Drawing.Font("Microsoft Sans Serif", 200F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_value_big.Location = new System.Drawing.Point(58, 430);
            this.lab_value_big.Name = "lab_value_big";
            this.lab_value_big.Size = new System.Drawing.Size(497, 302);
            this.lab_value_big.TabIndex = 73;
            this.lab_value_big.Text = "0.0";
            // 
            // uds_decoder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 368);
            this.Controls.Add(this.lab_value_big);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tb_settingsstring);
            this.Controls.Add(this.lab_msg_counter);
            this.Controls.Add(this.btn_com_port_refresh);
            this.Controls.Add(this.selector_com_port);
            this.Controls.Add(this.btn_connect);
            this.Name = "uds_decoder";
            this.Text = "UDS Decoder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.ComboBox selector_com_port;
        private System.Windows.Forms.TextBox tb_mult;
        private System.Windows.Forms.CheckBox cb_byte0;
        private System.Windows.Forms.TextBox tb_byte0;
        private System.Windows.Forms.TextBox tb_byte1;
        private System.Windows.Forms.CheckBox cb_byte1;
        private System.Windows.Forms.TextBox tb_byte2;
        private System.Windows.Forms.CheckBox cb_byte2;
        private System.Windows.Forms.TextBox tb_byte3;
        private System.Windows.Forms.CheckBox cb_byte3;
        private System.Windows.Forms.TextBox tb_byte4;
        private System.Windows.Forms.CheckBox cb_byte4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_add;
        private System.Windows.Forms.TextBox tb_val;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_div;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Button btn_com_port_refresh;
        private System.Windows.Forms.CheckBox cb_signed;
        private System.Windows.Forms.TextBox tb_br0;
        private System.Windows.Forms.TextBox tb_br1;
        private System.Windows.Forms.Label lab_msg_counter;
        private System.Windows.Forms.TextBox tb_byte5;
        private System.Windows.Forms.CheckBox cb_byte5;
        private System.Windows.Forms.TextBox tb_byte6;
        private System.Windows.Forms.CheckBox cb_byte6;
        private System.Windows.Forms.TextBox tb_byte7;
        private System.Windows.Forms.CheckBox cb_byte7;
        private System.Windows.Forms.TextBox tb_byte8;
        private System.Windows.Forms.CheckBox cb_byte8;
        private System.Windows.Forms.TextBox tb_byte9;
        private System.Windows.Forms.CheckBox cb_byte9;
        private System.Windows.Forms.TextBox tb_byte10;
        private System.Windows.Forms.CheckBox cb_byte10;
        private System.Windows.Forms.TextBox tb_byte11;
        private System.Windows.Forms.CheckBox cb_byte11;
        private System.Windows.Forms.TextBox tb_byte14;
        private System.Windows.Forms.CheckBox cb_byte14;
        private System.Windows.Forms.TextBox tb_byte13;
        private System.Windows.Forms.CheckBox cb_byte13;
        private System.Windows.Forms.TextBox tb_byte12;
        private System.Windows.Forms.CheckBox cb_byte12;
        private System.Windows.Forms.TextBox tb_act_value;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_factor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_byte15;
        private System.Windows.Forms.CheckBox cb_byte15;
        private System.Windows.Forms.TextBox tb_factor2;
        private System.Windows.Forms.Label lab_startbit;
        private System.Windows.Forms.Label lab_length;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_ax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_ay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_bx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_by;
        private System.Windows.Forms.Button btn_set_ax;
        private System.Windows.Forms.Button btn_set_ay;
        private System.Windows.Forms.Button btn_set_bx;
        private System.Windows.Forms.Button btn_set_by;
        private System.Windows.Forms.TextBox tb_ssr_t;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_ssr_m;
        private System.Windows.Forms.TextBox tb_settingsstring;
        private System.Windows.Forms.TextBox tb_bitmask;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_abc_int;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_abc_in;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tb_abc_bit;
        private System.Windows.Forms.CheckBox cb_isFloat;
        private System.Windows.Forms.Label lab_value_big;
    }
}

