using uiux_soft2.Models;

namespace uiux_soft2.Services;

public class OsakaDataService
{
    public List<TopicItem> GetTopics()
    {
        var topics = new List<TopicItem>
        {
            new TopicItem
            {
                IndexLabel = "01",
                Title = "観光地",
                Description = "大阪の観光地について紹介します。",
                IconType = "spots",
                GradientClass = "gradient-spots",
                Articles = new()
                {
                    new TopicArticle
                    {
                        Title = "道頓堀",
                        Body = "道頓堀は、大阪ミナミを代表するにぎやかな観光地です。グリコサインや巨大な立体看板が有名で、大阪らしい派手で活気のある街並みを楽しめます。たこ焼きやお好み焼きなどの食べ歩きもでき、観光と食文化を同時に味わえる場所です。",
                        ImagePath = "images/topic/doutonbori.avif"
                    },
                    new TopicArticle
                    {
                        Title = "ユニバーサル・スタジオ・ジャパン",
                        Body = "ユニバーサル・スタジオ・ジャパンは、大阪ベイエリアにある大型テーマパークです。映画や人気キャラクターの世界を再現したアトラクションが多く、子どもから大人まで楽しめます。大阪を代表する現代的な観光地の一つです。",
                        ImagePath = "images/topic/usj.avif"
                    },
                    new TopicArticle
                    {
                        Title = "海遊館",
                        Body = "海遊館は、大阪港エリアにある大規模な水族館です。太平洋を中心とした海の生き物を展示しており、ジンベエザメを見られる大きな水槽が特に有名です。海の生態系を学びながら楽しめる観光地です。",
                        ImagePath = "images/topic/kaiyuukan.avif"
                    },
                    new TopicArticle
                    {
                        Title = "黒門市場",
                        Body = "黒門市場は、大阪の食文化を感じられる市場です。新鮮な魚介類や果物、惣菜などを扱う店が並び、食べ歩きも楽しめます。観光客だけでなく地元の人にも利用されてきた、大阪らしい食のスポットです。",
                        ImagePath = "images/topic/kuromon.avif"
                    },
                    new TopicArticle
                    {
                        Title = "天王寺動物園",
                        Body = "天王寺動物園は、長い歴史を持つ大阪市内の動物園です。都市部にありながら多くの動物を見ることができ、家族連れにも人気があります。周辺には公園や商業施設もあり、散策と合わせて楽しめる場所です。",
                        ImagePath = "images/topic/tennouzidoubutuen.avif"
                    },
                    new TopicArticle
                    {
                        Title = "天神橋筋商店街",
                        Body = "天神橋筋商店街は、日本でも特に長い商店街として知られています。飲食店や日用品店が多く並び、観光地でありながら大阪の日常的な生活感も感じられます。食べ歩きや買い物を通して、庶民的な大阪の魅力を楽しめます。",
                        ImagePath = "images/topic/tenzinbasisuzi.avif"
                    },
                    new TopicArticle
                    {
                        Title = "万博記念公園",
                        Body = "万博記念公園は、1970年に開かれた大阪万博の跡地に整備された公園です。広い自然の中で散策を楽しめるだけでなく、博物館やイベント施設もあります。大阪の近現代の歴史と自然を同時に感じられる観光地です。",
                        ImagePath = "images/topic/banpakukouen.avif"
                    },
                    new TopicArticle
                    {
                        Title = "なんばグランド花月",
                        Body = "なんばグランド花月は、大阪のお笑い文化を代表する劇場です。漫才や落語、吉本新喜劇などを楽しむことができ、観光客にも人気があります。大阪らしい笑いの文化を直接体験できる場所です。",
                        ImagePath = "images/topic/nanbagurandokagetu.avif"
                    },
                    new TopicArticle
                    {
                        Title = "天保山大観覧車",
                        Body = "天保山大観覧車は、大阪港エリアにある大きな観覧車です。高い場所から大阪湾や市街地を眺めることができ、海遊館など周辺の観光地とも一緒に楽しめます。昼と夜で違った景色を見られる点も魅力です。",
                        ImagePath = "images/topic/daikanransya.avif"
                    },
                    new TopicArticle
                    {
                        Title = "中之島公園",
                        Body = "中之島公園は、堂島川と土佐堀川に囲まれた都心の公園です。水辺の景色やバラ園があり、落ち着いた雰囲気の中で散歩を楽しめます。周辺には歴史的な建物も多く、大阪の都市景観を感じられる場所です。",
                        ImagePath = "images/topic/nakanosimakouen.avif"
                    },
                }
            },
            new TopicItem
            {
                IndexLabel = "02",
                Title = "歴史",
                Description = "大阪の歴史について紹介します。",
                IconType = "history",
                GradientClass = "gradient-history",
                Articles = new()
                {
                    new TopicArticle
                    {
                        Title = "難波津",
                        Body = "難波津は、古代の大阪にあった重要な港です。海や川を利用した交通の中心として発展し、大陸や瀬戸内海方面との交流を支えました。大阪が昔から交通と物流の要所であったことを示す歴史的な題材です。",
                        ImagePath = "images/topic/naniwatu.avif"
                    },
                    new TopicArticle
                    {
                        Title = "難波宮",
                        Body = "難波宮は、古代に大阪へ置かれた宮殿です。現在の大阪市中心部に都が存在していたことを示す重要な史跡で、政治の中心地としての大阪の歴史を学ぶことができます。大阪が古くから重要な地域だったことを伝える存在です。",
                        ImagePath = "images/topic/naniwanomiya.avif"
                    },
                    new TopicArticle
                    {
                        Title = "大坂の陣",
                        Body = "大坂の陣は、豊臣家と徳川家が争った大きな戦いです。この戦いによって豊臣家は滅び、徳川幕府の支配がより強まりました。大阪の歴史を語るうえで、戦国時代から江戸時代への移り変わりを示す重要な出来事です。",
                        ImagePath = "images/topic/oosakanozin.avif"
                    },
                    new TopicArticle
                    {
                        Title = "天下の台所",
                        Body = "江戸時代の大坂は、全国から米や物資が集まる商業都市として栄えました。そのため、大坂は「天下の台所」と呼ばれるようになりました。商人の町として発展した大阪の特徴をよく表す歴史的な言葉です。",
                        ImagePath = "images/topic/tenkanodaidokoro.avif"
                    },
                    new TopicArticle
                    {
                        Title = "堂島米会所",
                        Body = "堂島米会所は、江戸時代の大坂で米の取引が行われた場所です。米の価格を決める重要な役割を持ち、商業都市としての大阪の発展に関わりました。大阪が経済の中心地として栄えたことを説明しやすい題材です。",
                        ImagePath = "images/topic/komekaisyo.avif"
                    },
                    new TopicArticle
                    {
                        Title = "適塾と緒方洪庵",
                        Body = "適塾は、緒方洪庵が開いた蘭学塾です。医学や西洋の学問を学ぶ場として、多くの優れた人材を育てました。大阪が商業だけでなく、学問や近代化にも関わっていたことを示す歴史的な場所です。",
                        ImagePath = "images/topic/tekizyuku.avif"
                    },
                    new TopicArticle
                    {
                        Title = "文楽",
                        Body = "文楽は、大阪と深い関わりを持つ伝統芸能です。人形、語り、三味線が一体となって物語を表現する点が特徴です。長い歴史を持つ文化として、大阪の芸能や庶民文化を紹介する題材に向いています。",
                        ImagePath = "images/topic/bungaku.avif"
                    },
                    new TopicArticle
                    {
                        Title = "水都大阪",
                        Body = "大阪は、川や堀を利用して発展してきた都市です。物資の運搬や人の移動に水路が活用され、商業の発展を支えました。現在も中之島や道頓堀などに、水の都としての面影を見ることができます。",
                        ImagePath = "images/topic/suitooosaka.avif"
                    },
                    new TopicArticle
                    {
                        Title = "大阪大空襲",
                        Body = "大阪大空襲は、太平洋戦争末期に大阪が受けた大規模な空襲です。多くの建物が焼失し、多くの人々が被害を受けました。戦争の悲惨さと、戦後に大阪が復興していった歴史を考えるうえで重要な出来事です。",
                        ImagePath = "images/topic/oosakadaikuusyuu.avif"
                    },
                    new TopicArticle
                    {
                        Title = "1970年大阪万博",
                        Body = "1970年大阪万博は、日本で初めて開かれた国際博覧会です。高度経済成長期の日本を象徴する大きなイベントで、多くの人が未来の技術や文化に触れました。現在の大阪のイメージにもつながる近現代史の重要な出来事です。",
                        ImagePath = "images/topic/1970banpaku.avif"
                    },
                }
            },
            new TopicItem
            {
                IndexLabel = "03",
                Title = "食べ物",
                Description = "大阪の美味しい食べ物について紹介します。",
                IconType = "food",
                GradientClass = "gradient-food",
                Articles = new()
                {
                    new TopicArticle
                    {
                        Title = "たこ焼き",
                        Body = "大阪を代表する粉もんグルメの代表格。外はカリッと、中はトロッとした食感が特徴で、出汁の効いた生地にタコ、紅生姜、天かすなどを入れて焼き上げます。ソース、マヨネーズ、青のり、かつお節をかけてアツアツを食べるのが定番です。",
                        ImagePath = "images/topic/takoyaki.avif"
                    },
                    new TopicArticle
                    {
                        Title = "お好み焼き",
                        Body = "キャベツと生地を混ぜ合わせて鉄板で焼き上げる、大阪のソウルフード。豚肉やイカなど好みの具材をのせ、甘辛いソースとマヨネーズで仕上げます。目の前の鉄板で焼いてコテ（ヘラ）で切り分けて食べるスタイルが親しまれています。",
                        ImagePath = "images/topic/okonomiyaki.avif"
                    },
                    new TopicArticle
                    {
                        Title = "串カツ",
                        Body = "肉や野菜、海鮮などを串に刺し、衣をつけてカラッと揚げた庶民的なグルメ。新世界エリアが発祥の地として有名です。ウスターソースをベースにしたタレをつけていただきます。「ソースの二度漬け禁止」という独特のルールが有名です。",
                        ImagePath = "images/topic/kusikatu.avif"
                    },
                    new TopicArticle
                    {
                        Title = "551の豚まん",
                        Body = "大阪土産やおやつとして絶大な人気を誇る手作りの豚まん。ほんのり甘いモチモチの皮（生地）の中に、ジューシーな豚肉と玉ねぎの餡がぎっしり詰まっています。大阪の駅や街頭で漂う香りは、地元の人々の食欲をそそるおなじみの光景です。",
                        ImagePath = "images/topic/butaman.avif"
                    },
                    new TopicArticle
                    {
                        Title = "きつねうどん",
                        Body = "大阪が発祥とされる、甘く煮た大きな油揚げがのったうどん。関西特有 of 薄色で昆布や鰹の出汁がしっかりと効いた上品なスープと、モチっとしたうどん、そして出汁をたっぷり吸い込んだ油揚げの相性が抜群です。",
                        ImagePath = "images/topic/kituneudon.avif"
                    },
                    new TopicArticle
                    {
                        Title = "肉吸い",
                        Body = "肉うどんからうどんを抜き、代わりに出汁と牛肉を味わう大阪独自の料理。難波の千とせが発祥とされ、吉本新喜劇の芸人が「二日酔いでうどんまでは入らないが、肉うどんの汁が飲みたい」と注文したことから誕生したユニークな歴史があります。",
                        ImagePath = "images/topic/nikusui.avif"
                    },
                    new TopicArticle
                    {
                        Title = "イカ焼き",
                        Body = "小麦粉の生地にカットしたイカを混ぜ込み、専用のプレス鉄板で一気に挟んで焼き上げる大阪名物のファストフード。モチモチとした弾力のある平たい生地に甘辛いソースがよく絡み、手軽につまめるおやつとして長く愛されています。",
                        ImagePath = "images/topic/ikayaki.avif"
                    },
                    new TopicArticle
                    {
                        Title = "どて焼き",
                        Body = "牛すじ肉を白味噌やみりんで時間をかけてじっくり煮込んだ、大阪の居酒屋や串カツ店でおなじみの味。トロトロになるまで柔らかく煮込まれた牛すじに、甘目で濃厚な味噌のコクとネギのシャキシャキ感が抜群に合います。",
                        ImagePath = "images/topic/doteyaki.avif"
                    },
                    new TopicArticle
                    {
                        Title = "てっちり",
                        Body = "大阪は日本におけるフグの消費量の大部分を占める「フグ食の街」です。その代表格である「てっちり」は、ふぐの身や野菜を昆布出汁の鍋で煮込み、ポン酢でいただく贅沢な鍋料理。締めには旨味が染み出たスープで作る雑炊が欠かせません。",
                        ImagePath = "images/topic/tettiri.avif"
                    },
                    new TopicArticle
                    {
                        Title = "箱寿司",
                        Body = "酢飯の間に鯛や穴子、エビ、卵焼きなどを美しく敷き詰め、木製の型で押し固めて作る大阪の伝統的な寿司。「二寸六分の芸能」とも呼ばれる職人技が光る逸品で、江戸前の握り寿司とは対照的に、時間が経っても美味しく食べられるよう工夫されています。",
                        ImagePath = "images/topic/hakozusi.avif"
                    }
                }
            }
        };

        foreach (var article in topics.SelectMany(topic => topic.Articles))
        {
            article.Id = Path.GetFileNameWithoutExtension(article.ImagePath);
        }

        return topics;
    }
}
