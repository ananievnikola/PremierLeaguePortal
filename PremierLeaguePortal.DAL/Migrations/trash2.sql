﻿DECLARE @var0 nvarchar(128)
SELECT @var0 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Blog')
AND col_name(parent_object_id, parent_column_id) = 'MyProperty';
IF @var0 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Blog] DROP CONSTRAINT [' + @var0 + ']')
ALTER TABLE [dbo].[Blog] DROP COLUMN [MyProperty]
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201709261623305_tags', N'PremierLeaguePortal.DAL.Migrations.Configuration',  0x1F8B0800000000000400DD5D596FE4B8117E0F90FF20F4531278BB7D642613A3BD0B8F8FDD467C61DAB3C8DB8096D86DC13A7A25CAE346905F9687FCA4FC85903A794AA4A456CB8B797153E4C762B1AA583CAAE67FFFF9EFFCA737DFB35E6114BB617036399A1E4E2C18D8A1E306EBB34982563F7C9AFCF4E31FFF30BF72FC37EBD7A2DE09A9875B06F1D9E419A1CDE96C16DBCFD007F1D477ED288CC3159ADAA13F034E383B3E3CFCFBECE8680631C4046359D6FC4B1220D787E90FFCF3220C6CB84109F06E43077A715E8EBF2C5354EB0EF830DE001B9E4D1E22E8BB30BA81609DC0873042C09B5E9EDF4C3106826F68629D7B2EC0642DA1B79A58200842041026FAF46B0C97280A83F572830B80F7B8DD405C6F05BC18E68339ADAAEB8EEBF0988C6B56352CA0EC2446A16F08787492336AC6376FC5EE49C948CCCA2BCC72B425A34ED97936F9EC85EB89C577747AE145A4929CD3D9FC4C49D3034B311507A59C607122FF0EAC8BC4434904CF0298A00878B869F2E4B9F63FE0F6317C81C15990781E4D2C26177F630A70D143146E6084B65FE02A1FC2C2995833B6DD8C6F5836A3DA64035C04E8E47862DDE1CEC193074B59A098B14461047F86018C0082CE0340084601C180293785DEB9BE7E81C08151D11F163FAC5613EB16BCDDC0608D9ECF26F8CF8975EDBE41A728C969F81AB8580B71231425B0A99B65F234504FA9960568F7FD6076AFC3685B7684B5797A45C4AEFA22CC5B3D24165D77E542E73E28402F31D4233643C6508B3895DFF81996B2F4390C3D080263A8124846567DD347B08E773F11112492AF41DD1D7875D7A9D67010E79B0DD6F5F40BB6C15846BF402FFD153FBB9B7C6AC9CC7E132A5E47A1FF25F4725BC57FFFB60C93C8C6843C8635951E41B486489FDA4C91163E584335A54C258E4AEA9B9C42BA828CBAF9AC32D5B5065CE0572B5BCEA1BC7FB32ED185A3E34F5ABA60A8BCD76E1423F2E7CED5F0060CD4D19D6BBF0CD2D1950F5CAFA697E30F1FFBEA052F5A2B37F27B30D6208EBF8791F30B889F77BFA8433B89B0C22F11F0373BEFEDE1390CE05DE23F0DE044507DF536358FDFC36B60636FED2A20AD3AE3DD84F64B98A0ABC0210BDE57649BAECE25402FE49CDB368CE36B2CCCD0B90893CA0353F9B0F570C4D03768B9AEFE35F5AC5C682F3CE0FAB1748DE5D7F0A26AB5D2CA6B08EBADA29AA94F7013AEDD408FD4A2AA9AD4AC4623A97935535209981EA5794D35A16985463AB35A9DFC98623745F0D219AAF3646ECB0DEF79BCB983685AB49E66B8D711C6C446FA652AC01E58DA8D2B67E758D7D939397A5A9D7CFAF01138271FFF0A4F3EFC1EF7B38495FB70B4D2E9239DEE7EBF437AFA157849DF5DB5D286D408F4AF0D29ECF8B521251317BFBAE9D1C6ACB9455119C36BD52FE4D954E738CA865607669843773E8C0D68A52E642DEA5F5B08EAF895452ECAD2AA64406DA47E5FD6BFA0772C12971DFBB43A6C49DBBEFF2396DD7B1A29A396307A85116EBBFBDD76DADFC3F336C6BEAD375C8F831CB5308E537A909EF69D151BEAE2258CEDC8DD645752E3387B365E2AFA5F26DEC712F15E8E55F77D3241D639F91E9A9EEF6F79B56A032D7E1576CF922A665BE7C4A7049ABB105BC4D71E585777DAAD562806B3F7950ACF11F65BBD2D9E537A256127E61692A3C1E2E42B001EB6CA98D1E9AEEC6C72284C2453FF310241BC4A67266F7054DFE00E7EAFEA1ED7D73D7F01F13372CBEA27E2B4651354376994F1ED67C64AC0114C177333A637633F03CF83D1966D73A4C3D9F3380E6D37E594FC4AAC3839647BBF0A1C4BEF18B15A3285BBB65BCC3F9794613525E4F2E6F73EB8841E44D03AB7B3E71F1720B6316F44138CC931A4AF3019147D92333496C2BF081DE3850146A4152037243196023740E22AE206B6BB019E16C7B8D69AAB106142D90FFFE5126E604006A7C5121D02943BA559D91737434D9C9ACF28493413D0FCBC585700F8C3E3B10928776AAD10D0FC586B10016539B607016559F2EE0434BB26D09D7FEECE606CE2C95E5628A433DB1E0C229C0CBBF6209B0C3F462F9AD24742AAA9AF7F3154CD7CF60AB269B61B702512D520F087D3A9E0E2983182F6B46A89953E48EAC800D91B265A9D325FAEC7214B765E2A02EBB661A2C6CBB47D47D6A866F337BC29527369003BA4E6844EE7F2F3EB9D18A16C1B4E5EBDE216E58E85D965950FCF85CD1B1E58BE7F8BF333095E3208F812224AADF156B4DAFA331A2A2824DB383F8D101A0B76A80147D848C84025BB0D03D8E28D442D6CEE231AC0E60F1A6A5133856A0225D64B8A9499B586E64D744869A0E4AF4252BD83A12AD7BF98E115447BE75B8EA9142C41D9B477A914964CB87803CA72A205970AF16AE6926CF365B2FDEAC4256EABA4E0523198DEB9944B693393241B00832D402716B1EEBA8243F9403A3348FE045DE44FB317AAEF875243CA8D7F0D776A3DCF263EB76508739EA76086D213D5F345CD9920F33E69E9C8ED77670EC88EFB451E34B9A6BACE293502A94CEBFA923DE9497107513A3FE5B7F92C0BCBCB0BE63345FCDEFC166C366EB0A6E2F9F2126B9905F35DFCB0340F6CF3338C99CDF09977D5CA9E50186171E0BE92482607A6EFF72F01024F809CBE5F38BE504DEAEA29D6FFA24BDA9B1367B0F00A8ADAE46F895B298636667EA0E820E740D778983E71B1D39B774EA9C4661609AE041E8824177E17A197F881DAD357B72EC2D06884A24C1F858A67A381A8627DAC32628D462A0B0D70CA6B3606A82CD547A203D1682CBA5C1F8D894563268EFEA08FC704A4D178CC077DBC2C4A8D06CA4A0C385F3D0360585F158B58F319A715C256515044611FCF6AB596CEABAC7F7B9D6F703434D4BF11613796808A8DA241A8627DAC2AFA8986AA4AF591AAF0261AA92AD547CAE3976898BCC810830A8111C0A86F061ACC4429312ACC7C31B0C76C28126393D94F0654D201470C91F48756780A8ECA6B18583221C488B16AC25703F916838D1841173FB7C096D0CC7FD34795C423D1C092CFFAD85570120D59958EC6DA4B4E33FA34FDE2219BB9F1D7C0D88DF92F2E8AF8293443A1E23E98A5BF2A36C4CA233B04B0BC7C94A2A53CA5EA47B4B283D66EA2A5C050DB24267C823549B5311F6A4C26268231FB7531216A3C33011E8198A8CEE9FA9192F4D0BA9B90C821766B408AAB221A45757DB4BF59CCCEAB7A9D3AD9619CCE7CC9DBED668D10DEF83350FC47435CF62DBF80CC7E36C416BD13AAD8C0A1141636D3358D798D4F03311F7E975BEDDD99BB8EA6CECCCC75D320C956764F2E327B8C2C9E848A372B66E79E627B9D634E7260CEB1ACEE1645E49AD69CF168F2B70914292DA954BECF682D59B55461F63B6EFA04671193588AF295BAD9D8F92B8676E2C3DC43198A0ED3B68BD848EE9D5A4E068DD497B848EED646252AF5636E1613E1428AAF52DAB8F2628ABB809AE79741CD592685DBA1ACCAC42A76136793E53646D09F920AD3E56FDE85E7A6370A45855B10B82B18A32C9A62727C7874CCE5A61C4F9EC8591C3B9EE4328D4F16C94ED80031672EE1686324A96178199B2A31780591FD0CA23FF9E0EDCF3456ABC48B9DD0B8E48ADDB0B8048A29273B674C74302A49DC7A4CE41CDA6E960DF66F7D24507C72CD0994244FD4A0502B6496CAADD86D1EF818D69E0894ADBB2CB99207898BC0816F67937FA518A7D6E29F828BB1700EACFB080BF4A97568FD5B0CF6342392B7F894286AD0C6B666E9AAA3A375FEC4C1CD5B35556A3EB74B44D84966F964839DC0F884829DC098A48152EEA5C1C12D40854474ADEC91243F60B7F5459603B013A224CF5F5F78BDB05095C7AF0D9632875F4F36589EE2AF0DA5CAF47E6D966D3EB99FFE8250B44C8B0FB02FFF35707F4BF08747CC0D6E39E014ADAF143E924BAA77EB68B2F9728CD6E5ACA9EE5ADC2E875A37BF46C8936600D721175A0BC9786769C47A730A1EC42C61BD61EF53B4DBA7066B213C83A7D5DAB79960936D195193351D646625518FEF75955064BAEA649D95D9ACBAA3F6E6CBD34B511B374792896A043BF576C9A8DEEFCEB39DA34906BD7B47B3EFF4302348682009BCDC7F1298212386EB1EC38D2C5D41B7542F2313B63C1C77FF095D861636D5F3B8910B9B51DA9691C95A1620BDF7EC2C434B9AE2DDC9C804CD28094B073913B38530C8594E04E33426EF452E14A17E623F7A6F4F86920B9D9C34D41B0EB36C317B9B7FD563CAFDCD7AF3F3910166BC654A9EB164E1D9E74AD3F0D4701CCBCCDED3EC8821DAFC9CB28957321350ED0519CB903DE0C1BBFAA710CF78B697D44AAC23AC534207E2D344495F594A68796E06BE4BC93E4EE85452A7BE5B45BE95BABE73B7BEB6EFBC4E7DDF8A2C26757D67DA57DB7556A5BE6779D603A1E36C05127BCBDF0C4ABAD0CB05C4DA37E5689A46221FC59E73063199261AD24C351D62284246E4B9A5C69C22A817A6307AA708B6EA9F29BBCA08D40B4B68059247167567C88E3200F5C50E7A79AB9E2EF734ECFEF2FC30B6940A2ADAC7D0769CC0472A9032611C44AC0D12F688EFA0B1F39604E4B623FB750963775D419007DE01B419B7ADACB3085661E13D72141555F887A5100107FB74E7117257C046F83379FF92FE470F79FEF72BFF093A8BE03E419B04E12143FFC9632EE389175AD77F9A9588A5797E9FDE16C57D0C0193E9920BA2FBE073E27A4E49F7B5E47A420141DCDBFC1E91CC2522F789EB6D897417069A4039FB4AAFFC11FA1B0F83C5F7C112BCC236B461F1BB816B606FABD7092A90E68960D93EBF74C13A027E9C6354EDF14F2CC38EFFF6E3FF016EE8C01D9A820000 , N'6.1.3-40302')

